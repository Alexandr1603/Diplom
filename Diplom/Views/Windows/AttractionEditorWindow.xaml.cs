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
using TA.Domain.Results;
using TA.Services.Attractions;

namespace TA.Desktop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AttractionEditorWindow.xaml
    /// </summary>
    public partial class AttractionEditorWindow : Window
    {
        private readonly AttractionsService _attractionsService = new();
        public AttractionBlank Attraction { get; set; }
        public AttractionEditorWindow(Guid? cityId, Attraction? attraction = null)
        {
            InitializeComponent();
            Attraction = attraction is null ? new AttractionBlank() :
                new AttractionBlank(attraction.Id, cityId.Value, attraction.Name, attraction.Time, attraction.Price);

            Attraction.Id_city = cityId.Value;
            edTime.Text = "0";
            edPrice.Text = "0";

            if (attraction is not null)
            {
                Title = "Редактирование достопримечательности";

                edPrice.Text = Convert.ToString(attraction.Price); 
                edName.Text = attraction.Name;
                edTime.Text = attraction.Time.Hours.ToString();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Attraction.Name = edName.Text;
            if (edTime.Text != "")
            {
                Attraction.Time = new TimeSpan(Convert.ToInt32(edTime.Text), 0, 0);
            }
            if (edPrice.Text != "")
            {
                Attraction.Price = Convert.ToInt32(edPrice.Text);
            }

            Result result = _attractionsService.SaveAttractionEntry(Attraction);
            if (!result.IsSuccess)
            {
                App.ShowMessage(result.Error);
                return;
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageResult = App.ShowMessage("Вы уверены, что хотите отменить изменения?", button: MessageBoxButton.YesNo);
            if (messageResult == MessageBoxResult.No) return;
            this.Close();
        }

        private void edTime_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.Text[0]);
        }

        private void edPrice_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 0)
            {
                (sender as TextBox).Text = "0";
            }
        }
    }
}
