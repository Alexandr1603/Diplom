using Diplom;
using System;
using System.Collections.Generic;
using System.Device.Location;
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
using TA.Domain.Customers;
using TA.Domain.Results;
using TA.Domain.RouteAttractions;
using TA.Domain.RouteHotels;
using TA.Domain.Routes;
using TA.Domain.RouteTransport;
using TA.Domain.TourClients;
using TA.Domain.Tours;
using TA.Services;
using TA.Services.Attractions;
using TA.Services.Cities;
using TA.Services.Customers;
using TA.Services.HotelRooms;
using TA.Services.Routes;
using TA.Services.TourClientsService;

namespace TA.Desktop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для TourWindow.xaml
    /// </summary>
    public partial class TourWindow : Window
    {
        private readonly TourService _tourService = new();
        private readonly TourClientsService _tourClientsService = new();
        private readonly CustomersService _customersService = new();
        private readonly CitiesService _citiesService = new();
        private readonly RoutesService _routesService = new();
        private readonly HotelRoomsService _hotelRoomsService = new();
        private readonly AttractionsService _attractionsService = new();
        private List<TourClientBlank> Customers = new List<TourClientBlank>();
        private List<RouteBlank> Routes = new List<RouteBlank>();
        public TourBlank Tour { get; set; }

        public TourWindow(Tour? tour = null)
        {
            InitializeComponent();
            Tour = tour is null ? new TourBlank() :
                new TourBlank(tour.Id, tour.Id_worker, tour.Discount, tour.Price, tour.Name, tour.DateStart, tour.DateEnd, tour.Price_discount);

            edDateStart.SelectedDate = DateTime.Now.Date;
            edDiscount.Text = "0";
            edPrice.Text = "0";

            if (tour is not null)
            {
                Title = "Редактирование тура";
                edName.Text = tour.Name;
                edPrice.Text = tour.Price.ToString();
                edDiscount.Text = tour.Discount.ToString();
                edDateStart.SelectedDate = tour.DateStart;
                edDateEnd.SelectedDate = tour.DateEnd;
                TourClient[] TourClients;
                TourClients = _tourClientsService.GetTourClients(tour.Id);
                foreach (var item in TourClients)
                {
                    Customers.Add(new TourClientBlank(item.Id, item.Id_client, item.Id_tour));
                }
                Route[] routes = _routesService.GetRoutesTour(tour.Id);
                foreach (var item in routes)
                {
                    var routeBlank = new RouteBlank(item.Id, item.Id_tour, _citiesService.GetCity(item.Id_city), item.Position, item.Days, item.Price);
                    routeBlank.RouteHotels = new();
                    routeBlank.RouteAttractions = new();
                    var routeH = _routesService.GetHotelRoute(item.Id);
                    foreach (var itemh in routeH)
                    {
                        routeBlank.RouteHotels.Add(new RouteHotelBlank(itemh.Id, itemh.Id_route, itemh.Id_room));
                    }
                    var routeA = _routesService.GetAttractionRoute(item.Id);
                    foreach (var itema in routeA)
                    {
                        routeBlank.RouteAttractions.Add(new RouteAttractionBlank(itema.Id, itema.Id_route, itema.Id_attraction));
                    }
                    Routes.Add(routeBlank);
                }
                LoadClients();
                LoadRoute();
                LoadTransport();
                LoadPrice();
            }
            ChangeDateEnd();
        }
        private (bool, Customer) SelectCustomer()
        {
            Customer entry = clientBox.SelectedItem as Customer;
            if (entry is null)
            {
                MessageBoxResult messageResult = App.ShowMessage("Выберите клиента из списка");
            }
            return ((entry is null), entry);
        }

        private (bool, string) SelectCity()
        {
            string Position = "";
            if (routBox.SelectedValue != null)
            {
                System.Type type = routBox.SelectedValue.GetType();
                Position = (string)type.GetProperty("Position").GetValue(routBox.SelectedValue, null);
            }
            else
            {
                MessageBoxResult messageResult = App.ShowMessage("Выберите точку маршрута из списка");
            }
            return ((Position == ""), Position);
        }

        private void LoadPrice()
        {
            int Price = 0;
            foreach (var item in Routes)
            {
                Price += item.Price;
            }
            foreach (var item in transportBox.Items)
            {
                System.Type type = item.GetType();
                Price += (int)type.GetProperty("Price").GetValue(item, null);
            }
            edPrice.Text = Price.ToString();
        }

        private void LoadClients()
        {
            List<Customer> customers = new List<Customer>();
            int discount = 0;
            foreach (var Customer in Customers)
            {
                var item = _customersService.GetCustomer(Customer.Id_client);
                customers.Add(item);
                discount = discount + item.Discount;
            }
            discount = discount / Customers.Count;
            edDiscount.Text = discount.ToString();
            clientBox.ItemsSource = null;
            clientBox.ItemsSource = customers;
        }

        private void LoadTransport()
        {
            transportBox.Items.Clear();
            transportBox.Items.Refresh();
            RouteBlank routeStart = null;
            RouteBlank routeEnd = null;
            foreach (var route in Routes)
            {
                routeEnd = route;
                if (!(routeStart is null))
                {
                    AddTransport(routeStart, routeEnd);
                }                
                routeStart = route;
            }
            AddTransport(routeStart, Routes[0]);
        }

        private void AddTransport(RouteBlank routeStart, RouteBlank routeEnd)
        {
            GeoCoordinate geoS = new GeoCoordinate(routeStart.City.Width, routeStart.City.Long);
            GeoCoordinate geoE = new GeoCoordinate(routeEnd.City.Width, routeEnd.City.Long);
            double dist = geoS.GetDistanceTo(geoE);
            dist = dist / 1000;
            double Price = 0;
            Transport tr;
            if (dist < 100)
            {
                tr = Transport.Bus;
                Price = dist * 3.1;
            }
            else if (dist > 450)
            {
                tr = Transport.Plane;
                if (routeStart.City.Id_country == routeEnd.City.Id_country)
                {
                    Price = dist * 4.1;
                }
                else
                {
                    Price = dist * 5.9;
                }
            }
            else
            {
                tr = Transport.Train;
                if (dist<250)
                {
                    Price = dist * 3.4;
                }
                else
                {
                    Price = dist * 4;
                }
            }
            transportBox.Items.Add(new
            {
                Name = routeStart.City.Name + " - " + routeEnd.City.Name,
                Transport = "(" + tr.GetDisplayName() + ")",
                Price = Convert.ToInt32(Price),
                Distance = Convert.ToInt32(dist) + "км. "
            });
        }

        private void LoadRoute()
        {
            routBox.Items.Clear();
            routBox.Items.Refresh();
            var Position = 0;
            foreach (var route in Routes)
            {
                var vis = Visibility.Visible;
                var position = "";
                route.Position = Position;
                position = route.Position.ToString(); 
                if (Position == 0)
                {
                    position = "Точка отправления";
                }
                position = position + ". ";
                int Price = 0;
                foreach (var item in route.RouteHotels)
                {
                    var room = _hotelRoomsService.GetHotelRoom(item.Id_room);
                    Price = Price + (room.Price * route.Days);
                }
                foreach (var item in route.RouteAttractions)
                {
                    var attr = _attractionsService.GetAttraction(item.Id_attraction);
                    Price = Price + (attr.Price * Customers.Count);
                }
                route.Price = Price;
                
                routBox.Items.Add(new
                {
                    CityName = route.City.Name + " ",
                    Position = position,
                    Price = "Цена: " + route.Price,
                    Vis = vis
                });
                if (Position == Routes.Count - 1)
                {
                    position = "Конечная точка. ";
                    vis = Visibility.Collapsed;
                    routBox.Items.Add(new
                    {
                        CityName = Routes[0].City.Name + " ",
                        Position = position,
                        Vis = vis
                    });
                }
                Position++;
            }
            transportBox.ItemsSource = null;
            transportBox.Items.Refresh();
            if (Routes.Count >= 2)
            {
                tbTrans.IsEnabled = true;
            }
            else
            {
                tbTrans.IsEnabled=false;
            }
        }

        private void ChangeDateEnd()
        {
            int MaxDays = 0;
            foreach (var item in Routes)
            {
                MaxDays = MaxDays + item.Days;
            }
            DateTime dateEnd = edDateStart.SelectedDate.Value;
            edDateEnd.SelectedDate = dateEnd.AddDays(MaxDays);
        }

        private void btnAddRoute_Click(object sender, RoutedEventArgs e)
        {
            CitiesWindow editor = new(true);
            editor.ShowDialog();
            if (editor.cityId is null) return;
            var route = new RouteBlank(null, null, _citiesService.GetCity(editor.cityId.Value), null, 1, 0);
            RouteWindow routeWindow = new(route);
            if (routeWindow.ShowDialog().Value)
            {
                route.Days = routeWindow.Days;
                route.RouteHotels = routeWindow.FrouteHotelBlanks;
                route.RouteAttractions = routeWindow.FrouteAttractionBlanks;
                if (route.RouteHotels != null)
                {
                    Routes.Add(route);
                    LoadRoute();
                    LoadTransport();
                    LoadPrice();
                    ChangeDateEnd();
                }
            }
        }

        private void btnDeleteRoute_Click(object sender, RoutedEventArgs e)
        {
            (bool check, string entry) = SelectCity();
            if (check) return;
            MessageBoxResult messageResult = App.ShowMessage("Вы уверены, что хотите удалить точку маршрут?", button: MessageBoxButton.YesNo);
            if (messageResult == MessageBoxResult.No) return;
            Routes.Remove(Routes[Convert.ToInt32(entry.Replace(".", string.Empty).Trim())]);
            LoadRoute();
            LoadTransport();
            LoadPrice();
            ChangeDateEnd();
        }

        private void roomBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            (bool check, string entry) = SelectCity();
            if (check) return;
            RouteBlank route;
            if (Char.IsDigit(entry[0]))
            {
                route = Routes[Convert.ToInt32(entry.Replace(".", string.Empty).Trim())];
            }
            else
            {
                route = Routes[0];
            }
            RouteWindow routeWindow = new(route);
            if (routeWindow.ShowDialog().Value)
            {
                route.RouteHotels = routeWindow.FrouteHotelBlanks;
                route.RouteAttractions = routeWindow.FrouteAttractionBlanks;
                route.Days = routeWindow.Days;
                LoadRoute();
                LoadTransport();
                LoadPrice();
                ChangeDateEnd();
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
            if (Customers.Count == 0)
            {
                App.ShowMessage("Для создания тура требуется минимум 1 клиент");
                return;
            }
            if (Routes.Count == 0)
            {
                App.ShowMessage("Маршрут должен состоять минимум из 2 точек (точка отправки и посещаемая)");
                return;
            }
            if (edDateStart.SelectedDate is null)
            {
                App.ShowMessage("Введите дату");
                return;
            }
            Tour.Name = edName.Text;
            Tour.Id_worker = App.CurrentWorker.Id;
            Tour.Discount = Convert.ToInt32(edDiscount.Text);
            Tour.Price = Convert.ToDouble(edPrice.Text);
            Tour.Price_discount = Convert.ToInt32(edPriceWithDiscount.Text); 
            Tour.DateStart = edDateStart.SelectedDate.Value;
            Tour.DateEnd = edDateEnd.SelectedDate.Value;

            Result result = _tourService.SaveTourEntry(Tour);
            if (!result.IsSuccess)
            {
                App.ShowMessage(result.Error);
                return;
            }
            result = _routesService.SaveRoutesEntry(Routes, Tour.Id.Value);
            if (!result.IsSuccess)
            {
                App.ShowMessage(result.Error);
                return;
            }
            result = _tourClientsService.SaveTourClientEntry(Customers, Tour.Id.Value);
            if (!result.IsSuccess)
            {
                App.ShowMessage(result.Error);
                return;
            }
            this.Close();
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            ClientsWindow editor = new(true);
            editor.ShowDialog();
            if (editor.clientId is null) return;
            Customers.Add(new TourClientBlank(null, editor.clientId.Value, null));
            LoadClients();
            LoadRoute();
        }

        private void btnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            (bool check, Customer entry) = SelectCustomer();
            if (check) return;
            MessageBoxResult messageResult = App.ShowMessage("Вы уверены, что хотите удалить клиента?", button: MessageBoxButton.YesNo);
            if (messageResult == MessageBoxResult.No) return;
            Customers.Remove(Customers.FirstOrDefault(x => x.Id_client == entry.Id));
            LoadClients();
            LoadRoute();
        }

        private void edDateStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (edDateStart.SelectedDate < DateTime.Now.Date || edDateStart.SelectedDate is null)
            {
                edDateStart.SelectedDate = DateTime.Now.Date;
            }
            ChangeDateEnd();
        }

        private void edPrice_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (edPrice.Text == "") return;
            edPriceWithDiscount.Text = ((Convert.ToInt32(edPrice.Text) * (100 - Convert.ToInt32(edDiscount.Text))) / 100).ToString();
        }

        private void edDiscount_SelectionChanged(object sender, RoutedEventArgs e)
        {
            edPrice_SelectionChanged(sender, null);
        }
    }
}
