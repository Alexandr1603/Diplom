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

namespace TA.Desktop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для RoomEditorWindow.xaml
    /// </summary>
    public partial class RoomEditorWindow : Window
    {
        public HotelRoomBlank HotelRoom { get; set; }
        public RoomEditorWindow(HotelRoomBlank? room = null)
        {
            InitializeComponent();
            HotelRoom = room is null ? new HotelRoomBlank() :
                new HotelRoomBlank(room.Id.Value, room.Id_hotel, room.Name, room.Price, room.Count_room);

            if (room is not null)
            {
                Title = "Редактирование номера";

                edName.Text = room.Name;
                edPrice.Text = Convert.ToString(room.Price);
                edCount.Text = Convert.ToString(room.Count_room);
            }
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
            if (edName.Text == "" || edCount.Text == "" || edPrice.Text == "")
            {
                App.ShowMessage("Данные не заполнены");
                return;
            }
            HotelRoom.Name = edName.Text;
            HotelRoom.Count_room = Convert.ToInt32(edCount.Text);
            HotelRoom.Price = Convert.ToInt32(edPrice.Text);
            this.DialogResult = true;
            this.Close();
        }

        private void edPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.Text[0]);
        }
    }
}
