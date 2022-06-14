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
    /// Логика взаимодействия для WorkerEditorWindow.xaml
    /// </summary>
    public partial class WorkerEditorWindow : Window
    {
        private readonly WorkersService _workersService = new();
        public WorkerBlank Worker { get; set; }
        public WorkerEditorWindow(Worker? worker = null)
        {
            InitializeComponent();
            Worker = worker is null ? new WorkerBlank() :
                new WorkerBlank(worker.Id, worker.Login, worker.Password, worker.Role);

            foreach (var value in Enum.GetValues<WorkerRole>())
            {
                roleBox.Items.Add(value);
            }

            if (worker is not null)
            {
                Title = "Редактирование пользователя";
                edLogin.IsEnabled = false;

                edLogin.Text = worker.Login;
                edPassword.Password = worker.Password;
                roleBox.SelectedItem = worker.Role;
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
            if (roleBox.SelectedValue is null)
            {
                App.ShowMessage("Выберите роль");
                return;
            }

            Worker.Login = edLogin.Text;
            Worker.Password = edPassword.Password;
            Worker.Role = (WorkerRole)roleBox.SelectedValue;

            Result result = _workersService.SaveWorkerEntry(Worker);
            if (!result.IsSuccess)
            {
                App.ShowMessage(result.Error);
                return;
            }

            this.Close();
        }
    }
}
