using Diplom;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TA.Domain.Countries;
using TA.Domain.Hotels;
using TA.Domain.Results;
using TA.Services;
using TA.Services.Cities;
using TA.Services.Countries;
using TA.Services.HotelRooms;
using TA.Services.Hotels;
using TA.Services.Routes;

namespace TA.Desktop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для HotelsWindow.xaml
    /// </summary>
    public partial class HotelsWindow : Window
    {
        private readonly CitiesService _citiesService = new();
        private readonly CountriesService _countriesService = new();
        private readonly HotelRoomsService _hotelRoomsService = new();
        private readonly HotelsService _hotelsService = new();
        private readonly TourService _tourService = new();
        private readonly RoutesService _routesService = new();
        public Hotel[] Hotels { get; set; }
        private Guid? cityId;
        public HotelsWindow()
        {
            InitializeComponent();
            var Countries = _countriesService.GetAllCountries();
            ObservableCollection<TreeViewItem> nodes = new ObservableCollection<TreeViewItem>();
            foreach (Country country in Countries)
            {
                var node = new TreeViewItem
                {
                    Header = country.Name
                };
                var Cities = _citiesService.GetCountryCities(country.Id);
                foreach (City city in Cities)
                {
                    node.Items.Add(new TreeViewItem
                    {
                        Header = city.Name,
                    });
                };
                node.IsExpanded = true;
                nodes.Add(node);
                if (nodes.Count == 1 && node.Items.Count > 0) { ((TreeViewItem)nodes[0].Items[0]).IsSelected = true; }
            }
            treeView1.ItemsSource = nodes;
            this.DataContext = this;
        }

        private (bool, Hotel) SelectHotel()
        {
            Hotel entry = hotelsBox.SelectedItem as Hotel;
            if (entry is null)
            {
                MessageBoxResult messageResult = App.ShowMessage("Выберите отель из списка");
            }
            return ((entry is null), entry);
        }

        private void hotelsBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            (bool check, Hotel entry) = SelectHotel();
            if (check) return;

            hotelsBox.SelectedIndex = -1;
            HotelEditorWindow editor = new(cityId, entry);
            editor.ShowDialog();

            treeView1_SelectedItemChanged(sender, null);
        }

        private void treeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            City city = _citiesService.GetCity((treeView1.SelectedItem as TreeViewItem).Header.ToString());
            if (city != null)
            {
                Hotels = _hotelsService.GetCityHotels(city.Id);
                this.DataContext = null;
                this.DataContext = this;
                cityId = city.Id;
            }
            else
            {
                cityId = null; 
                Hotels = null;
            }
            RefreshControl();
        }

        private void RefreshControl()
        {
            var rfr = cityId != null;
            btnAddHotel.IsEnabled = rfr;
            btnDeleteHotel.IsEnabled = rfr;
            btnEditHotel.IsEnabled = rfr;
        }

        private void btnDeleteCity_Click(object sender, RoutedEventArgs e)
        {
            (bool check, Hotel entry) = SelectHotel();
            if (check) return;
            MessageBoxResult messageResult = App.ShowMessage("Вы уверены, что хотите удалить отель?", button: MessageBoxButton.YesNo);
            if (messageResult == MessageBoxResult.No) return;

            var rooms = _hotelRoomsService.GetRoomsHotel(entry.Id);
            bool RouteEmpty = true;
            foreach (var item in _tourService.GetAllTours())
            {
                var Routs = _routesService.GetRoutesTour(item.Id);
                Routs = Routs.OrderBy(x => x.Position).ToArray();
                foreach (var route in Routs)
                {
                    foreach (var item1 in _routesService.GetHotelRoute(route.Id))
                    {
                        foreach (var room in rooms)
                        {
                            if (room.Id == item1.Id_room)
                            {
                                RouteEmpty = false;
                            }
                        }
                    }
                }
            }

            if (RouteEmpty)
            {
                foreach (var room in rooms)
                {
                    _hotelRoomsService.DeleteHotelRoom(room.Id);
                }
                _hotelsService.DeleteHotel(entry.Id);
                treeView1_SelectedItemChanged(sender, null);
            }
            else
            {
                App.ShowMessage("Отель используется");
            }
        }

        private void btnEditCity_Click(object sender, RoutedEventArgs e)
        {
            hotelsBox_MouseDoubleClick(sender, null);
        }

        private void btnAddCity_Click(object sender, RoutedEventArgs e)
        {
            HotelEditorWindow editor = new(cityId, null);
            editor.ShowDialog();

            treeView1_SelectedItemChanged(sender, null);
        }
    }
}
