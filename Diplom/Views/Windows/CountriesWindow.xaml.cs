using Diplom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TA.Domain.Countries;
using TA.Services.Cities;
using TA.Services.Countries;

namespace TA.Desktop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для CountriesWindow.xaml
    /// </summary>
    public partial class CountriesWindow : Window
    {
        private readonly CountriesService _countriesService = new();
        private readonly CitiesService _citiesService = new();
        public Country[] Countries { get; set; }
        public CountriesWindow()
        {
            InitializeComponent();
            LoadCountries();
            this.DataContext = this;
        }

        private (bool, Country) SelectCountry()
        {
            Country entry = countriesBox.SelectedItem as Country;
            if (entry is null)
            {
                MessageBoxResult messageResult = App.ShowMessage("Выберите страну из списка");
            }
            return ((entry is null), entry);
        }
        private void LoadCountries()
        {
            Countries = _countriesService.GetAllCountries();
            this.DataContext = null;
            this.DataContext = this;

        }

        private void countriesBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            (bool check, Country entry) = SelectCountry();
            if (check) return;

            countriesBox.SelectedIndex = -1;
            CountryEditorWindow editor = new(entry);
            editor.ShowDialog();

            LoadCountries();
        }

        private void btnAddWorker_Click(object sender, RoutedEventArgs e)
        {
            CountryEditorWindow editor = new(null);
            editor.ShowDialog();

            LoadCountries();
        }

        private void btnEditWorker_Click(object sender, RoutedEventArgs e)
        {
            countriesBox_MouseDoubleClick(sender, null);
        }

        private void btnDeleteWorker_Click(object sender, RoutedEventArgs e)
        {
            (bool check, Country entry) = SelectCountry();
            if (check) return;
            MessageBoxResult messageResult = App.ShowMessage("Вы уверены, что хотите удалить страну?", button: MessageBoxButton.YesNo);
            if (messageResult == MessageBoxResult.No) return;

            if (_citiesService.GetCountryCities(entry.Id).Count() == 0)
            {
                _countriesService.DeleteCountry(entry.Id);
            }
            else
            {
                App.ShowMessage("У страны есть города");
            }
        }
    }
}
