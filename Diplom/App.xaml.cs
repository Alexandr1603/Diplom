using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using TA.Desktop.Views.Windows;
using TA.Domain.Workers;

namespace Diplom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static BaseWindow Base = App.Current.MainWindow as BaseWindow;

        public static Worker CurrentWorker;

        public static bool ShowColor = true;

        public static MessageBoxResult ShowMessage(String error, String title = "Информация",
            MessageBoxButton button = MessageBoxButton.OK, MessageBoxImage image = MessageBoxImage.Asterisk)
        {
            return MessageBox.Show(error, title, button, image);
        }
        public static void UnhandledExceptionHandler(object sender, DispatcherUnhandledExceptionEventArgs args)
        {
            MessageBox.Show($"Произошла неизвестная ошибка:{Environment.NewLine}{args.Exception.Message}", "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);

            args.Handled = true;
        }
    }
}
