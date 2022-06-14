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
using TA.Domain.Attractions;
using TA.Domain.Hotels;
using TA.Domain.Results;
using TA.Domain.Rooms;
using TA.Domain.RouteAttractions;
using TA.Domain.RouteHotels;
using TA.Domain.Routes;
using TA.Services.Attractions;
using TA.Services.HotelRooms;
using TA.Services.Hotels;

namespace TA.Desktop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для RouteWindowWindow.xaml
    /// </summary>
    public partial class RouteWindow : Window
    {
        private readonly HotelRoomsService _hotelRoomsService = new();
        private readonly HotelsService _hotelsService = new();
        private readonly AttractionsService _attractionsService = new();
        public List<RouteHotelBlank> FrouteHotelBlanks;
        public List<RouteAttractionBlank> FrouteAttractionBlanks;
        private Guid FcityId;
        public int Days;
        public RouteWindow(RouteBlank route)
        {
            InitializeComponent();
            FrouteHotelBlanks = route.RouteHotels;
            FrouteAttractionBlanks = route.RouteAttractions;
            FcityId = route.City.Id;
            edDays.Text = route.Days.ToString();
            if (FrouteHotelBlanks != null)
            {
                LoadRooms();
                LoadAttractions();
            }
            else 
            { 
                FrouteHotelBlanks = new();
                FrouteAttractionBlanks= new();
            }
        }

        private void LoadAttractions()
        {
            List<Attraction> attractions = new List<Attraction>();
            foreach (var item in FrouteAttractionBlanks)
            {
                var attraction = _attractionsService.GetAttraction(item.Id_attraction);
                attractions.Add(attraction);
            }
            attractionsBox.ItemsSource = attractions;
        }

        private void LoadRooms()
        {
            treeView1.ItemsSource = null;
            treeView1.Items.Refresh();
            roomsBox.ItemsSource = null;
            roomsBox.Items.Refresh();
            List<Hotel> hotels = new();
            foreach (var item in FrouteHotelBlanks)
            {
                var room = _hotelRoomsService.GetHotelRoom(item.Id_room);
                var hotel = _hotelsService.GetHotel(room.Id_hotel);
                if (hotels.FirstOrDefault(x => x.Id == hotel.Id) == null)
                {
                    hotels.Add(hotel);
                }
            }
            List<TreeViewItem> nodes = new List<TreeViewItem>();
            foreach (var hotel in hotels)
            {
                nodes.Add(new TreeViewItem { Header = hotel.Name });
                if (nodes.Count == 1) { nodes[0].IsSelected = true; }
            }
            treeView1.ItemsSource = nodes;
        }
        private (bool, HotelRoom) SelectRoom()
        {
            HotelRoom entry = roomsBox.SelectedItem as HotelRoom;
            if (entry is null)
            {
                MessageBoxResult messageResult = App.ShowMessage("Выберите номер из списка");
            }
            return ((entry is null), entry);
        }
        private (bool, Attraction) SelectAttraction()
        {
            Attraction entry = attractionsBox.SelectedItem as Attraction;
            if (entry is null)
            {
                MessageBoxResult messageResult = App.ShowMessage("Выберите достопримечательность из списка");
            }
            return ((entry is null), entry);
        }

        private void btnDeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            (bool check, HotelRoom entry) = SelectRoom();
            if (check) return;
            MessageBoxResult messageResult = App.ShowMessage("Вы уверены, что хотите удалить номер?", button: MessageBoxButton.YesNo);
            if (messageResult == MessageBoxResult.No) return;
            RouteHotelBlank roombl = null;
            foreach (var item in FrouteHotelBlanks)
            {
                var room = _hotelRoomsService.GetHotelRoom(item.Id_room);
                if (room.Id == entry.Id)
                {
                    roombl = item;
                    break;
                }
            }
            FrouteHotelBlanks.Remove(roombl);
            LoadRooms();
        }

        private void btnAddRoom_Click(object sender, RoutedEventArgs e)
        {
            SelectRoomWindow editor = new(FcityId);
            editor.ShowDialog();
            if (editor.roomId is null) return;
            var route = new RouteHotelBlank(null, null, editor.roomId.Value);
            FrouteHotelBlanks.Add(route);
            LoadRooms();
        }

        private void treeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (treeView1.SelectedItem == null) { return; };
            var hotel = _hotelsService.GetHotel((treeView1.SelectedItem as TreeViewItem).Header.ToString());
            if (hotel != null)
            {
                List<HotelRoom> rooms = new List<HotelRoom>();
                foreach (var item in FrouteHotelBlanks)
                {
                    var room = _hotelRoomsService.GetHotelRoom(item.Id_room);
                    rooms.Add(room);
                }
                
                roomsBox.ItemsSource = rooms;
            }
        }

        private void btnAddAttraction_Click(object sender, RoutedEventArgs e)
        {
            int Hour = 0;
            foreach (var item in FrouteAttractionBlanks)
            {
                var attraction = _attractionsService.GetAttraction(item.Id_attraction);
                Hour = Hour + attraction.Time.Hours;
            }
            if (Hour > ((Convert.ToInt32(edDays.Text) * 24) - ((Convert.ToInt32(edDays.Text) - 1) * 10)))
            {
                App.ShowMessage("Вы больше не успеете посетить достопримечательности");
                return;
            }
            AttractionsWindow editor = new(true, FcityId);
            editor.ShowDialog();
            if (editor.attractionId is null) return;
            var route = new RouteAttractionBlank(null, null, editor.attractionId.Value);
            FrouteAttractionBlanks.Add(route);
            LoadAttractions();
        }

        private void btnDeleteAttraction_Click(object sender, RoutedEventArgs e)
        {
            (bool check, Attraction entry) = SelectAttraction();
            if (check) return;
            MessageBoxResult messageResult = App.ShowMessage("Вы уверены, что хотите удалить достопримечательность?", button: MessageBoxButton.YesNo);
            if (messageResult == MessageBoxResult.No) return;
            RouteAttractionBlank attrbl = null;
            foreach (var item in FrouteAttractionBlanks)
            {
                var attr = _attractionsService.GetAttraction(item.Id_attraction);
                if (attr.Id == entry.Id)
                {
                    attrbl = item;
                    break;
                }
            }
            FrouteAttractionBlanks.Remove(attrbl);
            LoadAttractions();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageResult = App.ShowMessage("Вы уверены, что хотите отменить изменения?", button: MessageBoxButton.YesNo);
            if (messageResult == MessageBoxResult.No) return;
            this.DialogResult = false;
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Days = Convert.ToInt32(edDays.Text);
            if (FrouteHotelBlanks.Count == 0 && Days > 1)
            {
                App.ShowMessage("Укажите место проживание (дней проживания больще одного)");
                return;
            }
            this.DialogResult = true;
            this.Close();
        }

        private void edDays_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.Text[0]);
        }

        private void edDays_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //int Hour = 0;
            //if (FrouteAttractionBlanks is null) return;
            //foreach (var item in FrouteAttractionBlanks)
            //{
            //    var attraction = _attractionsService.GetAttraction(item.Id_attraction);
            //    Hour = Hour + attraction.Time.Hours;
            //}
            //if (Hour > ((Convert.ToInt32(edDays.Text) * 24) - ((Convert.ToInt32(edDays.Text) - 1) * 10)))
            //{
            //    App.ShowMessage("Вы больше не успеете посетить достопримечательности");
            //    edDays.Text = Days.ToString();
            //    return;
            //}
            //Days = Convert.ToInt32(edDays.Text);
        }
    }
}
