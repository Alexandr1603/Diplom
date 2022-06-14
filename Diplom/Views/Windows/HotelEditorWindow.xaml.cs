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
using TA.Domain.Hotels;
using TA.Domain.Results;
using TA.Domain.Rooms;
using TA.Services.HotelRooms;
using TA.Services.Hotels;

namespace TA.Desktop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для HotelEditorWindow.xaml
    /// </summary>
    public partial class HotelEditorWindow : Window
    {
        private readonly HotelsService _hotelsService = new();
        private readonly HotelRoomsService _hotelRoomsService = new();
        public List<HotelRoomBlank> HotelRooms = new List<HotelRoomBlank>();
        public HotelBlank Hotel { get; set; }

        public HotelEditorWindow(Guid? cityId, Hotel? hotel = null)
        {
            InitializeComponent();
            Hotel = hotel is null ? new HotelBlank() :
                new HotelBlank(hotel.Id, cityId.Value, hotel.Name, hotel.Stars);

            Hotel.Id_city = cityId.Value;

            if (hotel is not null)
            {
                Title = "Редактирование отеля";

                var hotelRooms = _hotelRoomsService.GetRoomsHotel(hotel.Id);
                foreach (var item in hotelRooms)
                {
                    HotelRooms.Add(new HotelRoomBlank(item.Id, item.Id_hotel, item.Name, item.Price, item.Count_room));
                }
                roomBox.ItemsSource = null;
                roomBox.ItemsSource = HotelRooms;
                this.DataContext = this;
                edName.Text = hotel.Name;
                edStars.Text = Convert.ToString(hotel.Stars);
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
            Hotel.Name = edName.Text;
            Hotel.Stars = Convert.ToInt32(edStars.Text); 

            Result result = _hotelsService.SaveHotelEntry(Hotel);
            if (!result.IsSuccess)
            {
                App.ShowMessage(result.Error);
                return;
            }
            foreach (var item in HotelRooms)
            {
                item.Id_hotel = Hotel.Id;   
                result = _hotelRoomsService.SaveHotelRoomEntry(item);
                if (!result.IsSuccess)
                {
                    App.ShowMessage(result.Error);
                    return;
                }
            }

            this.Close();
        }

        private (bool, HotelRoomBlank) SelectRoom()
        {
            HotelRoomBlank entry = roomBox.SelectedItem as HotelRoomBlank;
            if (entry is null)
            {
                MessageBoxResult messageResult = App.ShowMessage("Выберите номер из списка");
            }
            return ((entry is null), entry);
        }

        private void roomBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            (bool check, HotelRoomBlank entry) = SelectRoom();
            if (check) return;

            roomBox.SelectedIndex = -1;
            RoomEditorWindow editor = new(entry);
            if (editor.ShowDialog().Value)
            {
                HotelRooms.Remove(entry);
                HotelRooms.Add(editor.HotelRoom);
            }
            this.DataContext = this;
        }

        private void btnAddRoom_Click(object sender, RoutedEventArgs e)
        {
            RoomEditorWindow editor = new(null);
            if (editor.ShowDialog().Value)
            {
                HotelRooms.Add(editor.HotelRoom);
            }
            roomBox.ItemsSource = null;
            roomBox.ItemsSource = HotelRooms;
        }

        private void btnEditRoom_Click(object sender, RoutedEventArgs e)
        {
            roomBox_MouseDoubleClick(sender, null);
        }

        private void btnDeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            (bool check, HotelRoomBlank entry) = SelectRoom();
            if (check) return;
            MessageBoxResult messageResult = App.ShowMessage("Вы уверены, что хотите удалить комнату?", button: MessageBoxButton.YesNo);
            if (messageResult == MessageBoxResult.No) return;

            HotelRooms.Remove(entry);
            roomBox.ItemsSource = null;
            roomBox.ItemsSource = HotelRooms;
        }

        private void edStars_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.Text[0]);
        }
    }
}
