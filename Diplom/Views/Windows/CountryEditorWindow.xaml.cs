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
using TA.Domain.Results;
using TA.Domain.Countries;
using TA.Services.Countries;

namespace TA.Desktop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для CountryEditorWindow.xaml
    /// </summary>
    public partial class CountryEditorWindow : Window
    {
        private readonly CountriesService _countriesService = new();
        public CountryBlank Country { get; set; }
        public CountryEditorWindow(Country? country = null)
        {
            InitializeComponent();
            Country = country is null ? new CountryBlank() :
                new CountryBlank(country.Id, country.Name);

            if (country is not null)
            {
                Title = "Редактирование пользователя";

                edName.Text = country.Name;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageResult = App.ShowMessage("Вы уверены, что хотите отменить изменения?", button: MessageBoxButton.YesNo);
            if (messageResult == MessageBoxResult.No) return;
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Country.Name = edName.Text;

            Result result = _countriesService.SaveCountryEntry(Country);
            if (!result.IsSuccess)
            {
                App.ShowMessage(result.Error);
                return;
            }

            this.Close();
        }
    }
}
