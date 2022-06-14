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
using TA.Domain.Workers;
using TA.Services.Workers;

namespace TA.Desktop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для WorkersWindow.xaml
    /// </summary>
    public partial class WorkersWindow : Window
    {
        private readonly WorkersService _workersService = new();
        public Worker[] Workers { get; set; }
        public WorkersWindow()
        {
            InitializeComponent();
            LoadWorkers();
            this.DataContext = this;
        }

        private (bool, Worker) SelectWorker()
        {
            Worker entry = workersBox.SelectedItem as Worker;
            if (entry is null)
            {
                MessageBoxResult messageResult = App.ShowMessage("Выберите работника из списка");
            }
            return ((entry is null), entry);
        }
        private void LoadWorkers()
        {
            Workers = _workersService.GetAllWorkers();
            this.DataContext = null;
            this.DataContext = this;

        }

        private void btnAddWorker_Click(object sender, RoutedEventArgs e)
        {
            WorkerEditorWindow editor = new(null);
            editor.ShowDialog();

            LoadWorkers();
        }

        private void btnDeleteWorker_Click(object sender, RoutedEventArgs e)
        {
            (bool check, Worker entry) = SelectWorker();
            if (check) return;
            MessageBoxResult messageResult = App.ShowMessage("Вы уверены, что хотите удалить класс?", button: MessageBoxButton.YesNo);
            if (messageResult == MessageBoxResult.No) return;

            _workersService.DeleteWorker(entry.Id);
        }

        private void btnEditWorker_Click(object sender, RoutedEventArgs e)
        {
            workersBox_MouseDoubleClick(sender, null);
        }

        private void workersBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            (bool check, Worker entry) = SelectWorker();
            if (check) return;

            workersBox.SelectedIndex = -1;
            WorkerEditorWindow editor = new(entry);
            editor.ShowDialog();

            LoadWorkers();
        }
    }
}
