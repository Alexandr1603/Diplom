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
using TA.Domain.Rooms;
using TA.Services.HotelRooms;
using TA.Services.Hotels;

namespace TA.Desktop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для SelectRoomWindow.xaml
    /// </summary>
    public partial class SelectRoomWindow : Window
    {
        private readonly HotelRoomsService _hotelRoomsService = new();
        public HotelRoom[] HotelRooms { get; set; }

        private readonly HotelsService _hotelsService = new();
        public Guid? roomId;
        public SelectRoomWindow(Guid cityId)
        {
            InitializeComponent();
            var Hotels = _hotelsService.GetCityHotels(cityId);
            List<TreeViewItem> nodes = new List<TreeViewItem>();
            foreach (var hotel in Hotels)
            {
                nodes.Add(new TreeViewItem { Header = hotel.Name });
                if (nodes.Count == 1) { nodes[0].IsSelected = true; }
            }
            treeView1.ItemsSource = nodes;
            this.DataContext = this;
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

        private void treeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var hotel = _hotelsService.GetHotel((treeView1.SelectedItem as TreeViewItem).Header.ToString());
            if (hotel != null)
                HotelRooms = _hotelRoomsService.GetRoomsHotel(hotel.Id);
            this.DataContext = null;
            this.DataContext = this;
        }

        private void roomsBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            (bool check, HotelRoom entry) = SelectRoom();
            if (check) return;
            roomId = entry.Id;
            this.Close();
        }
    }
}
