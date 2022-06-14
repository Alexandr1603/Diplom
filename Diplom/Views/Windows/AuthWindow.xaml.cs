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
using TA.Domain.Workers;
using TA.Services.Workers;

namespace TA.Desktop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private readonly WorkersService _workersService = new();
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            string userLogin = edLogin.Text.Trim();
            string userPassword = edPassword.Password.Trim();
            if (userLogin == "")
            {
                App.ShowMessage("Введите логин");
                return;
            }
            else if (userPassword == "")
            {
                App.ShowMessage("Введите пароль");
                return;
            }

            Worker worker = _workersService.GetWorker(userLogin);
            Result result = _workersService.EntryWorker(worker, userPassword);

            if (!result.IsSuccess)
            {
                App.ShowMessage(result.Error);
                return;
            }
            else
            {
                App.Base.Title = "Менеджер туров (" + worker.Login + " - " + worker.Role.GetDisplayName() + ")";
                App.CurrentWorker = worker;
                
                App.Base.RefreshControl();
                this.DialogResult = true;
                this.Close();
            }            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
        }
    }
}
