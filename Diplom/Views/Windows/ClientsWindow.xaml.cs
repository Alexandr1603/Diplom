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
using TA.Domain.Customers;
using TA.Domain.Workers;
using TA.Services;
using TA.Services.Customers;
using TA.Services.TourClientsService;

namespace TA.Desktop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientsWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {
        private readonly CustomersService _customersService = new();
        private readonly TourService _tourService = new();
        private readonly TourClientsService _tourClientsService = new();
        public Customer[] Customers { get; set; }
        private bool FSelectedMod;
        public Guid? clientId;
        public ClientsWindow(bool selectedMod = false)
        {
            InitializeComponent();
            LoadCustomers();
            this.DataContext = this;
            FSelectedMod = selectedMod;
            if (FSelectedMod && (App.CurrentWorker.Role == WorkerRole.Manager))
            {
                btnDeleteClient.Visibility = Visibility.Collapsed;
                btnEditClient.Visibility = Visibility.Collapsed;
            }
        }

        private (bool, Customer) SelectCustomer()
        {
            Customer entry = clientsBox.SelectedItem as Customer;
            if (entry is null)
            {
                MessageBoxResult messageResult = App.ShowMessage("Выберите клиента из списка");
            }
            return ((entry is null), entry);
        }
        private void LoadCustomers()
        {
            Customers = _customersService.GetAllCustomers();
            this.DataContext = null;
            this.DataContext = this;

        }

        private void clientsBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (FSelectedMod)
            {
                (bool check, Customer entry) = SelectCustomer();
                if (check) return;
                clientId = entry.Id;
                this.Close();
            }
            else
            {
                btnEditClient_Click(sender, e);
            }
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            ClientEditorWindow editor = new(null);
            editor.ShowDialog();

            LoadCustomers();
        }

        private void btnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            (bool check, Customer entry) = SelectCustomer();
            if (check) return;
            MessageBoxResult messageResult = App.ShowMessage("Вы уверены, что хотите удалить клиента?", button: MessageBoxButton.YesNo);
            if (messageResult == MessageBoxResult.No) return;

            bool RouteEmpty = true;
            foreach (var item in _tourService.GetAllTours())
            {
                var Customers = _tourClientsService.GetTourClients(item.Id);
                foreach (var item1 in Customers)
                {
                    if (item1.Id_client == entry.Id)
                    {
                        RouteEmpty = false;
                    }
                }
            }
            if (RouteEmpty)
            {
                _customersService.DeleteCustomer(entry.Id);
                LoadCustomers();
            }
            else
            {
                App.ShowMessage("Клиент используется");
            }
           
        }

        private void btnEditClient_Click(object sender, RoutedEventArgs e)
        {
            (bool check, Customer entry) = SelectCustomer();
            if (check) return;
            clientsBox.SelectedIndex = -1;
            ClientEditorWindow editor = new(entry);
            editor.ShowDialog();

            LoadCustomers();
        }
    }
}
