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
using TA.Domain.Attractions;
using TA.Domain.Cities;
using TA.Domain.Countries;
using TA.Domain.Results;
using TA.Domain.Workers;
using TA.Services.Attractions;
using TA.Services.Cities;
using TA.Services.Countries;

namespace TA.Desktop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AttractionsWindow.xaml
    /// </summary>
    public partial class AttractionsWindow : Window
    {
        private readonly CitiesService _citiesService = new();
        private readonly CountriesService _countriesService = new();
        private readonly AttractionsService _attractionsService = new();
        public Attraction[] Attractions { get; set; }
        private Guid? cityId;
        private bool FSelectedMod;
        public Guid? attractionId;
        public AttractionsWindow(bool SelectedMod = false, Guid? cityId = null)
        {
            InitializeComponent();
            FSelectedMod = SelectedMod;
            if (FSelectedMod && (App.CurrentWorker.Role == WorkerRole.Manager))
            {
                menu.Visibility = Visibility.Collapsed;
            }
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
                    var item = new TreeViewItem
                    {
                        Header = city.Name,
                    };
                    if (SelectedMod && city.Id == cityId)
                    {
                        item.IsSelected = true;
                    }
                    node.Items.Add(item);
                };
                node.IsExpanded = true;
                nodes.Add(node);
                if (!SelectedMod)
                {
                    if (nodes.Count == 1) { ((TreeViewItem)nodes[0].Items[0]).IsSelected = true; }
                }
            }
            treeView1.ItemsSource = nodes;
            this.DataContext = this;
            if (FSelectedMod)
            {
                treeView1.IsEnabled = false;
            }
        }
        private (bool, Attraction) SelectAttraction()
        {
            Attraction entry = AttractionsBox.SelectedItem as Attraction;
            if (entry is null)
            {
                MessageBoxResult messageResult = App.ShowMessage("Выберите достопримечательность из списка");
            }
            return ((entry is null), entry);
        }

        private void btnDeleteAttraction_Click(object sender, RoutedEventArgs e)
        {
            (bool check, Attraction entry) = SelectAttraction();
            if (check) return;
            MessageBoxResult messageResult = App.ShowMessage("Вы уверены, что хотите удалить город?", button: MessageBoxButton.YesNo);
            if (messageResult == MessageBoxResult.No) return;

            _attractionsService.DeleteAttraction(entry.Id);
        }

        private void btnEditAttraction_Click(object sender, RoutedEventArgs e)
        {
            (bool check, Attraction entry) = SelectAttraction();
            if (check) return;

            AttractionsBox.SelectedIndex = -1;
            AttractionEditorWindow editor = new(cityId, entry);
            editor.ShowDialog();

            treeView1_SelectedItemChanged(sender, null);
        }

        private void btnAddAttraction_Click(object sender, RoutedEventArgs e)
        {
            AttractionEditorWindow editor = new(cityId, null);
            editor.ShowDialog();

            treeView1_SelectedItemChanged(sender, null);
        }

        private void treeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            City city = _citiesService.GetCity((treeView1.SelectedItem as TreeViewItem).Header.ToString());
            if (city != null)
            {
                Attractions = _attractionsService.GetCityAttractions(city.Id);
                this.DataContext = null;
                this.DataContext = this;
                cityId = city.Id;
            }
            else
            {
                cityId = null;
                Attractions = null;
            }
            RefreshControl();
        }
        private void RefreshControl()
        {
            var rfr = cityId != null;
            btnAddAttraction.IsEnabled = rfr;
            btnDeleteAttraction.IsEnabled = rfr;
            btnEditAttraction.IsEnabled = rfr;
        }

        private void AttractionsBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (FSelectedMod)
            {
                (bool check, Attraction entry) = SelectAttraction();
                if (check) return;
                attractionId = entry.Id;
                this.Close();
            }
            else
            {
                btnEditAttraction_Click(sender, null);
            }
        }
    }
}
