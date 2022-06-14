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
using TA.Domain.Cities;
using TA.Services.Cities;
namespace TA.Desktop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для CityEditorWindow.xaml
    /// </summary>
    public partial class CityEditorWindow : Window
    {
        private readonly CitiesService _citiesService = new();
        public CityBlank City { get; set; }

        public CityEditorWindow(Guid countryId, City? city = null)
        {
            InitializeComponent();
            City = city is null ? new CityBlank() :
                new CityBlank(city.Id, city.Name, city.Id_country, city.Width, city.Long);

            City.Id_country = countryId;

            if (city is not null)
            {
                Title = "Редактирование города";

                edName.Text = city.Name;
                edWidth.Text = city.Width.ToString();
                edLong.Text = city.Long.ToString();
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
            City.Name = edName.Text;
            if (edWidth.Text != "")
            {
                City.Width = Convert.ToDouble(edWidth.Text);
            }
            if (edLong.Text != "")
            {
                City.Long = Convert.ToDouble(edLong.Text);
            }
            
            Result result = _citiesService.SaveCountryEntry(City);
            if (!result.IsSuccess)
            {
                App.ShowMessage(result.Error);
                return;
            }

            this.Close();
        }

        private void edWidth_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.Text[0]) && !(e.Text[0] == ',');
        }
    }
}
