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
using TA.Domain.Customers;
using TA.Services.Customers;

namespace TA.Desktop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientEditorWindow.xaml
    /// </summary>
    public partial class ClientEditorWindow : Window
    {
        private readonly CustomersService _customersService = new();
        public CustomerBlank Customer { get; set; }
        public ClientEditorWindow(Customer? customer = null)
        {
            InitializeComponent();
            Customer = customer is null ? new CustomerBlank() :
                new CustomerBlank(customer.Id, customer.Name, customer.Surname, customer.Patronymic, customer.Discount, customer.Passport, customer.Phone, customer.Email);

            if (customer is not null)
            {
                Title = "Редактирование клиента";

                edName.Text = customer.Name;
                edSurname.Text = customer.Surname;
                edPatronomic.Text = customer.Patronymic;
                edDiscoint.Text = Convert.ToString(customer.Discount);
                edPassport.Text = customer.Passport;
                edPhone.Text = customer.Phone;
                edEmail.Text = customer.Email;
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
            Customer.Name = edName.Text;
            Customer.Surname = edSurname.Text;
            Customer.Patronymic = edPatronomic.Text;
            if (edDiscoint.Text != "")
            {
                Customer.Discount = Convert.ToInt32(edDiscoint.Text);
            }
            Customer.Passport = edPassport.Text;
            Customer.Phone = edPhone.Text;
            Customer.Email = edEmail.Text;

            Result result = _customersService.SaveCustomerEntry(Customer);
            if (!result.IsSuccess)
            {
                App.ShowMessage(result.Error);
                return;
            }

            this.Close();
        }

        private void edPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.Text[0]);
        }

        private void edPassport_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.Text[0]);
        }
    }
}
