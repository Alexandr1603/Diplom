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
using TA.Domain.Cities;
using TA.Services.Cities;
using TA.Domain.Countries;
using TA.Services.Countries;
using System.Collections.ObjectModel;
using TA.Domain.Results;
using TA.Services.Attractions;
using TA.Services.Hotels;
using TA.Services;
using TA.Services.Routes;
using TA.Domain.Workers;

namespace TA.Desktop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для CitiesWindow.xaml
    /// </summary>

    public partial class CitiesWindow : Window
    {
        private readonly CitiesService _citiesService = new();
        private readonly AttractionsService _attractionsService = new();
        private readonly HotelsService _hotelsService = new();
        private readonly TourService _tourService = new();
        private readonly RoutesService _routesService = new();
        public City[] Cities { get; set; }

        private readonly CountriesService _countriesService = new();
        private Guid countryId;
        private bool FSelectedMod;
        public Guid? cityId;
        public CitiesWindow(bool selectedMod = false)
        {
            InitializeComponent();
            FSelectedMod = selectedMod;
            if (selectedMod && (App.CurrentWorker.Role == WorkerRole.Manager))
            {
                menu.Visibility = Visibility.Collapsed;
            }
            var Countries = _countriesService.GetAllCountries();
            ObservableCollection<TreeViewItem> nodes = new ObservableCollection<TreeViewItem>();
            foreach (Country country in Countries)
            {
                nodes.Add(new TreeViewItem { Header = country.Name });
                if (nodes.Count == 1) { nodes[0].IsSelected = true; }
            }
            treeView1.ItemsSource = nodes;
            this.DataContext = this;
        }

        private (bool, City) SelectCity()
        {
            City entry = citiesBox.SelectedItem as City;
            if (entry is null)
            {
                MessageBoxResult messageResult = App.ShowMessage("Выберите город из списка");
            }
            return ((entry is null), entry);
        }

        private void citiesBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (FSelectedMod)
            {
                (bool check, City entry) = SelectCity();
                if (check) return;
                cityId = entry.Id;
                this.Close();
            }
            else
            {
                btnEditCity_Click(sender, null);
            }
        }

        private void btnDeleteCity_Click(object sender, RoutedEventArgs e)
        {
            (bool check, City entry) = SelectCity();
            if (check) return;
            MessageBoxResult messageResult = App.ShowMessage("Вы уверены, что хотите удалить город?", button: MessageBoxButton.YesNo);
            if (messageResult == MessageBoxResult.No) return;

            bool RouteEmpty = true;
            foreach (var item in _tourService.GetAllTours())
            {
                var Routs = _routesService.GetRoutesTour(item.Id);
                Routs = Routs.OrderBy(x => x.Position).ToArray();
                foreach (var route in Routs)
                {
                    if (route.Id == entry.Id)
                    {
                        RouteEmpty = false;
                    }
                }
            }

            if ((_attractionsService.GetCityAttractions(entry.Id).Count() == 0) && (_hotelsService.GetCityHotels(entry.Id).Count() == 0) && RouteEmpty)
            {
                _citiesService.DeleteCity(entry.Id);
            }
            else
            {
                App.ShowMessage("Город используется");
            }
        }

        private void btnEditCity_Click(object sender, RoutedEventArgs e)
        {
            (bool check, City entry) = SelectCity();
            if (check) return;
            citiesBox.SelectedIndex = -1;
            CityEditorWindow editor = new(countryId, entry);
            editor.ShowDialog();

            treeView1_SelectedItemChanged(sender, null);
        }

        private void btnAddCity_Click(object sender, RoutedEventArgs e)
        {
            CityEditorWindow editor = new(countryId, null);
            editor.ShowDialog();

            treeView1_SelectedItemChanged(sender, null);
        }

        private void treeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (treeView1.SelectedItem is null) return;
            Country country = _countriesService.GetCountry((treeView1.SelectedItem as TreeViewItem).Header.ToString());
            if (country != null)
                Cities = _citiesService.GetCountryCities(country.Id);
            this.DataContext = null;
            this.DataContext = this;
            countryId = country.Id;
        }
    }
}
