using Diplom;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using TA.Domain.Cities;
using TA.Domain.Countries;
using TA.Domain.Customers;
using TA.Domain.Routes;
using TA.Domain.RouteTransport;
using TA.Domain.Tours;
using TA.Domain.Workers;
using TA.Services;
using TA.Services.Cities;
using TA.Services.Countries;
using TA.Services.Customers;
using TA.Services.Routes;
using TA.Services.TourClientsService;
using TA.Services.Workers;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace TA.Desktop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для BaseWindow.xaml
    /// </summary>
    /// 
    public class TransportExp
    {
        public string Name { get; set; }
        public string Transport { get; set; }
        public int Price { get; set; }
        public string Distance { get; set; }
        public TransportExp(string name, string transport, int price, string distance)
        {
            Name = name;
            Transport = transport;
            Price = price;
            Distance = distance;
        }
    }
    public partial class BaseWindow : Window
    {
        private readonly TourService _tourService = new();
        private readonly WorkersService _workersService = new();
        private readonly TourClientsService _tourClientsService = new();
        private readonly CitiesService _citiesService = new();
        private readonly CustomersService _customersService = new();
        private readonly CountriesService _countriesService = new();
        private readonly RoutesService _routesService = new();
        private XmlDocument doc = new XmlDocument();
        public Tour[] Tours { get; set; }
        public BaseWindow()
        {
            InitializeComponent();
            App.Current.Dispatcher.UnhandledException += App.UnhandledExceptionHandler;
        }

        private (bool, Tour) SelectTour()
        {
            Tour entry = null;
            Guid? Id = null;
            if (tourBox.SelectedValue != null)
            {
                System.Type type = tourBox.SelectedValue.GetType();
                Id = (Guid)type.GetProperty("Id").GetValue(tourBox.SelectedValue, null);
                entry = _tourService.GetTour(Id.Value);
            }
            else
            {
                MessageBoxResult messageResult = App.ShowMessage("Выберите тур из списка");
            }
            return ((entry is null), entry);
        }
        private void LoadTours()
        {
            if (App.CurrentWorker.Role == WorkerRole.Admin)
            {
                Tours = _tourService.GetAllTours();
            }
            else
            {
                Tours = _tourService.GetWorkerTours(App.CurrentWorker.Id);
            }
            if (edSearch.Text != "" && btnSearch.IsChecked)
            {
                Tours = Tours.Where(x => x.Name.Contains(edSearch.Text)).ToArray();
            }
            switch (cbSort.SelectedIndex)
            {

                case 0:
                    Tours = Tours.OrderBy(x => x.Name).ToArray();
                    break;
                case 1:
                    Tours = Tours.OrderBy(x => x.DateStart).ToArray();
                    break;

                case 2:
                    Tours = Tours.OrderBy(x => x.DateEnd).ToArray();
                    break;
            }
            Worker worker = null;
            City city = _citiesService.GetCity((treeView1.SelectedItem as TreeViewItem).Header.ToString());
            if (city == null)
            {
                worker = _workersService.GetWorker((treeView1.SelectedItem as TreeViewItem).Header.ToString());
            }
            if (city == null && worker == null) return;
            tourBox.Items.Clear();
            tourBox.Items.Refresh();
            for (int i = 0; i < Tours.Count(); i++)
            {
                tourBox.Items.Add(new
                {
                    Name = Tours[i].Name,
                    Id = Tours[i].Id,
                    Price = Tours[i].Price_discount,
                    DateStart = Tours[i].DateStart,
                    DateEnd = Tours[i].DateEnd,
                    Worker = _workersService.GetWorker(Tours[i].Id_worker).Login
                });
            }
            for (int i = 0; i < tourBox.Items.Count; i++)
            {
                Visibility vis = Visibility.Collapsed;
                if (city == null && (Tours[i].Id_worker == worker.Id))
                {
                    vis = Visibility.Visible;
                }
                else
                {
                    Route[] routes = _routesService.GetRoutesTour(Tours[i].Id);
                    foreach (var item in routes)
                    {
                        if (city != null && item.Id_city == city.Id)
                        {
                            vis = Visibility.Visible;
                        }
                    }
                }
                var listBoxItem = tourBox.ItemContainerGenerator.ContainerFromIndex(i);

                if (App.ShowColor)
                {
                    var bc = new BrushConverter();
                    if (Tours[i].DateStart > DateTime.Now)
                    {
                        (listBoxItem as ListBoxItem).Background = (Brush)bc.ConvertFrom("#ffffcb");
                    }
                    else if (Tours[i].DateEnd < DateTime.Now)
                    {
                        (listBoxItem as ListBoxItem).Background = (Brush)bc.ConvertFrom("#ffcdcd");
                    }
                    else
                    {
                        (listBoxItem as ListBoxItem).Background = (Brush)bc.ConvertFrom("#b4ffcb");
                    }
                }
                (listBoxItem as ListBoxItem).Visibility = vis;
            }
            RefreshControl();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            doc.Load("Settings.xml");

            App.ShowColor = bool.Parse((doc.DocumentElement["ShowColor"] as XmlNode).InnerText);
            RefreshControl();
            AuthWorker();
        }

        public void RefreshControl()
        {
            bool IsWorker = App.CurrentWorker != null;
            menuReferences.IsEnabled = IsWorker && App.CurrentWorker.Role == WorkerRole.Admin;
            btnAddTour.IsEnabled = IsWorker;
            btnEditTour.IsEnabled = IsWorker && tourBox.Items.Count > 0;
            btnDeleteTour.IsEnabled = IsWorker && tourBox.Items.Count > 0;
            btnExport.IsEnabled = IsWorker && tourBox.Items.Count > 0;
        }

        private void AuthWorker()
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Owner = this;
            if (authWindow.ShowDialog().Value)
            {
                cbGroup.SelectedIndex = 0;
                cbSort.SelectedIndex = 0;
                cbiWorker.IsEnabled = App.CurrentWorker.Role != WorkerRole.Manager;
            }
        }

        private void btnSelectWorker_Click(object sender, RoutedEventArgs e)
        {
            AuthWorker();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void btnWorkers_Click(object sender, RoutedEventArgs e)
        {
            WorkersWindow workersWindow = new WorkersWindow();
            workersWindow.Owner = this;
            workersWindow.ShowDialog();
        }

        private void btnCountries_Click(object sender, RoutedEventArgs e)
        {
            CountriesWindow countriesWindow = new CountriesWindow();
            countriesWindow.Owner = this;
            countriesWindow.ShowDialog();
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            ClientsWindow clientsWindow = new ClientsWindow();
            clientsWindow.Owner = this;
            clientsWindow.ShowDialog();
        }

        private void btnCities_Click(object sender, RoutedEventArgs e)
        {
            CitiesWindow citiesWindow = new CitiesWindow();
            citiesWindow.Owner = this;
            citiesWindow.ShowDialog();
        }

        private void btnHotels_Click(object sender, RoutedEventArgs e)
        {
            HotelsWindow hotelsWindow = new HotelsWindow();
            hotelsWindow.Owner = this;
            hotelsWindow.ShowDialog();
        }

        private void btnAttractions_Click(object sender, RoutedEventArgs e)
        {
            AttractionsWindow attractionsWindow = new AttractionsWindow();
            attractionsWindow.Owner = this;
            attractionsWindow.ShowDialog();
        }

        private void tourBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            (bool check, Tour entry) = SelectTour();
            if (check) return;

            tourBox.SelectedIndex = -1;
            TourWindow editor = new(entry);
            editor.ShowDialog();

            LoadTours();
        }

        private void btnAddTour_Click(object sender, RoutedEventArgs e)
        {
            TourWindow editor = new(null);
            editor.ShowDialog();

            LoadTours();
        }

        private void btnEditTour_Click(object sender, RoutedEventArgs e)
        {
            tourBox_MouseDoubleClick(sender, null);
        }

        private void btnDeleteTour_Click(object sender, RoutedEventArgs e)
        {
            (bool check, Tour entry) = SelectTour();
            if (check) return;
            MessageBoxResult messageResult = App.ShowMessage("Вы уверены, что хотите удалить тур?", button: MessageBoxButton.YesNo);
            if (messageResult == MessageBoxResult.No) return;

            _tourService.DeleteTour(entry.Id);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            LoadTours();
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (treeView1.SelectedItem is null) return;
            LoadTours();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            (doc.DocumentElement["ShowColor"] as XmlNode).InnerText = App.ShowColor.ToString();
            doc.Save("Settings.xml");
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow hotelsWindow = new SettingsWindow();
            hotelsWindow.Owner = this;
            hotelsWindow.ShowDialog();
            LoadTours();
        }
     
        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".pdf";
            sfd.Filter = "Pdf документ (.pdf)|*.pdf";
            var res = sfd.ShowDialog();
            if (res == true)
            {
                iTextSharp.text.Document doc = new iTextSharp.text.Document();

                //Создаем объект записи пдф-документа в файл
                PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));

                //Открываем документ
                doc.Open();

                string ttf = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
                var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font5 = new Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

                PdfPTable pdfTable = new PdfPTable(7);
                float[] widths = new float[] { 7f, 7f, 7f, 7f, 7f, 7f, 7f };
                pdfTable.SetWidths(widths);
                pdfTable.WidthPercentage = 100;
                PdfPCell cell = new PdfPCell(new Phrase("Туры из списка", font5));

                cell.Colspan = 7;
                cell.HorizontalAlignment = 1;
                //Убираем границу первой ячейки, чтобы балы как заголовок
                cell.Border = 0;
                pdfTable.AddCell(cell);


                pdfTable.AddCell(new PdfPCell(new Phrase("Работник", font5)));
                pdfTable.AddCell(new PdfPCell(new Phrase("Название", font5)));
                pdfTable.AddCell(new PdfPCell(new Phrase("Цена", font5)));
                pdfTable.AddCell(new PdfPCell(new Phrase("Скидка %", font5)));
                pdfTable.AddCell(new PdfPCell(new Phrase("Дата начала", font5)));
                pdfTable.AddCell(new PdfPCell(new Phrase("Дата оцончания", font5)));
                pdfTable.AddCell(new PdfPCell(new Phrase("Клиент", font5)));



                //Adding DataRow
                foreach (var row in Tours)
                {
                    pdfTable.AddCell(new PdfPCell(new Phrase(_workersService.GetWorker(row.Id_worker).Login, font5)));
                    pdfTable.AddCell(new PdfPCell(new Phrase(row.Name, font5)));
                    pdfTable.AddCell(new PdfPCell(new Phrase((row.Price_discount).ToString(), font5)));
                    pdfTable.AddCell(new PdfPCell(new Phrase(row.Discount.ToString(), font5)));
                    pdfTable.AddCell(new PdfPCell(new Phrase(row.DateStart.Date.ToString(), font5)));
                    pdfTable.AddCell(new PdfPCell(new Phrase(row.DateEnd.Date.ToString(), font5)));
                    var client = _customersService.GetCustomer(_tourClientsService.GetTourClients(row.Id)[0].Id_client).Initials;
                    pdfTable.AddCell(new PdfPCell(new Phrase(client, font5)));
                }
                doc.Add(pdfTable);
                doc.Close();
                App.ShowMessage("Pdf-документ сохранен");
            }
        }

        private void treeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (App.CurrentWorker is null) return;
            LoadTours();
        }

        private void cbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (App.CurrentWorker is null) return;
            ObservableCollection<TreeViewItem> nodes = new ObservableCollection<TreeViewItem>();
            switch (cbGroup.SelectedIndex)
            {
                case 0:
                    NameGroup.Text = "Города тура";
                    var Countries = _countriesService.GetAllCountries();
                    foreach (Country country in Countries)
                    {
                        var node = new TreeViewItem
                        {
                            Header = country.Name
                        };
                        var Cities = _citiesService.GetCountryCities(country.Id);
                        foreach (City city in Cities)
                        {
                            node.Items.Add(new TreeViewItem
                            {
                                Header = city.Name,
                            });
                        };
                        node.IsExpanded = true;
                        nodes.Add(node);
                        if (nodes.Count == 1) { ((TreeViewItem)nodes[0].Items[0]).IsSelected = true; }
                    }
                    treeView1.ItemsSource = nodes;
                    this.DataContext = this;
                    break;
                case 1:
                    NameGroup.Text = "Работники";
                    var Workers = _workersService.GetAllWorkers();
                    foreach (Worker worker in Workers)
                    {
                        var node = new TreeViewItem
                        {
                            Header = worker.Login
                        };
                        node.IsExpanded = true;
                        nodes.Add(node);
                        if (nodes.Count == 1) { ((TreeViewItem)nodes[0]).IsSelected = true; }
                    }
                    treeView1.ItemsSource = nodes;
                    this.DataContext = this;
                    break;
            }
        }

        private void btnExportXLSX_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".xlsx";
            sfd.Filter = "Excel документ (.xlsx)|*.xlsx";
            var res = sfd.ShowDialog();
            if (res == true)
            {
                Excel.Application xlApp = new Excel.Application();
                xlApp.Visible = false;
                xlApp.DisplayAlerts = false;
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet sheet = (Excel.Worksheet)xlWorkbook.Worksheets[1];
                sheet.Name = "Туры из списка";
                Excel.Range range = sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, 7]].Cells;
                sheet.Cells[1, 1] = "Туры";
                Excel.Range titleRange = (Excel.Range)sheet.Cells[1, 1];
                titleRange.HorizontalAlignment = Excel.Constants.xlCenter;
                range.Merge();
                sheet.Cells[2, 1] = "Название";
                sheet.Cells[2, 2] = "Цена";
                sheet.Cells[2, 3] = "Цена со скидкой";
                sheet.Cells[2, 4] = "Скидка";
                sheet.Cells[2, 5] = "Дата начала";
                sheet.Cells[2, 6] = "Дата окончания";
                sheet.Cells[2, 7] = "Дата окончания";

                int i = 3;
                foreach (var tour in Tours)
                {
                    sheet.Cells[i, 1] = tour.Name;
                    sheet.Cells[i, 2] = tour.Price;
                    sheet.Cells[i, 3] = tour.Price_discount;
                    sheet.Cells[i, 4] = tour.Discount;
                    sheet.Cells[i, 5] = tour.DateStart.Date;
                    sheet.Cells[i, 6] = tour.DateEnd.Date;
                    var client = _customersService.GetCustomer(_tourClientsService.GetTourClients(tour.Id)[0].Id_client).Initials;
                    sheet.Cells[i, 7] = client;
                    i++;
                }
                Excel.Range sheetRange = sheet.Columns;
                sheetRange.AutoFit();
                sheet.SaveAs(sfd.FileName);
                xlApp.Quit();
                sheet = null;
                xlApp = null;
                App.ShowMessage("xlsx-документ сохранен");
            }
        }

        private void AddTransport(List<TransportExp> tran, Route routeStart, Route routeEnd)
        {
            GeoCoordinate geoS = new GeoCoordinate(_citiesService.GetCity(routeStart.Id_city).Width, _citiesService.GetCity(routeStart.Id_city).Long);
            GeoCoordinate geoE = new GeoCoordinate(_citiesService.GetCity(routeEnd.Id_city).Width, _citiesService.GetCity(routeEnd.Id_city).Long);
            double dist = geoS.GetDistanceTo(geoE);
            dist = dist / 1000;
            double Price = 0;
            Transport tr;
            if (dist < 100)
            {
                tr = Transport.Bus;
                Price = dist * 3.1;
            }
            else if (dist > 450)
            {
                tr = Transport.Plane;
                if (_citiesService.GetCity(routeStart.Id_city).Id_country == _citiesService.GetCity(routeEnd.Id_city).Id_country)
                {
                    Price = dist * 4.1;
                }
                else
                {
                    Price = dist * 5.9;
                }
            }
            else
            {
                tr = Transport.Train;
                if (dist < 250)
                {
                    Price = dist * 3.4;
                }
                else
                {
                    Price = dist * 4;
                }
            }
            tran.Add(new TransportExp(_citiesService.GetCity(routeStart.Id_city).Name + " - " + _citiesService.GetCity(routeEnd.Id_city).Name, "(" + tr.GetDisplayName() + ")",
                Convert.ToInt32(Price), Convert.ToInt32(dist) + "км. "));
        }

        private void btnExportXML_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            (bool check, Tour tour) = SelectTour();
            if (check) return;
            sfd.DefaultExt = ".xlsx";
            sfd.Filter = "Excel документ (.xlsx)|*.xlsx";
            var res = sfd.ShowDialog();
            if (res == true)
            {
                Excel.Application xlApp = new Excel.Application();
                xlApp.Visible = false;
                xlApp.DisplayAlerts = false;
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet sheet = (Excel.Worksheet)xlWorkbook.Worksheets[1];
                sheet.Name = "Тур";
                Excel.Range range = sheet.Range[sheet.Cells[1, 1], sheet.Cells[2, 7]].Cells;
                sheet.Cells[1, 1] = "Тур";
                Excel.Range range1 = sheet.Range[sheet.Cells[1, 9], sheet.Cells[1, 17]].Cells;
                sheet.Cells[1, 9] = "Данные";
                Excel.Range range2 = sheet.Range[sheet.Cells[2, 9], sheet.Cells[2, 10]].Cells;
                sheet.Cells[2, 9] = "Клиенты";
                Excel.Range range3 = sheet.Range[sheet.Cells[2, 11], sheet.Cells[2, 13]].Cells;
                sheet.Cells[2, 11] = "Маршрут";
                Excel.Range range4 = sheet.Range[sheet.Cells[2, 14], sheet.Cells[2, 17]].Cells;
                sheet.Cells[2, 14] = "Проезд";
                Excel.Range titleRange = (Excel.Range)sheet.Cells[1, 1];
                titleRange.HorizontalAlignment = Excel.Constants.xlCenter;
                range.Merge();
                range1.Merge();
                range2.Merge();
                range3.Merge();
                range4.Merge();
                sheet.Cells[3, 1] = "Название";
                sheet.Cells[3, 2] = "Цена";
                sheet.Cells[3, 3] = "Цена со скидкой";
                sheet.Cells[3, 4] = "Скидка";
                sheet.Cells[3, 5] = "Дата начала";
                sheet.Cells[3, 6] = "Дата окончания";
                sheet.Cells[3, 7] = "Работник";
                sheet.Cells[3, 9] = "Инициалы";
                sheet.Cells[3, 10] = "Скидка";
                sheet.Cells[3, 11] = "Позиция";
                sheet.Cells[3, 12] = "Название";
                sheet.Cells[3, 13] = "Цена";
                sheet.Cells[3, 14] = "Название";
                sheet.Cells[3, 15] = "Транспорт";
                sheet.Cells[3, 16] = "Цена";
                sheet.Cells[3, 17] = "Дистанция";

                int i = 4;
                sheet.Cells[i, 1] = tour.Name;
                sheet.Cells[i, 2] = tour.Price;
                sheet.Cells[i, 3] = tour.Price_discount;
                sheet.Cells[i, 4] = tour.Discount;
                sheet.Cells[i, 5] = tour.DateStart;
                sheet.Cells[i, 6] = tour.DateEnd;
                sheet.Cells[i, 7] = _workersService.GetWorker(tour.Id_worker).Login;
                var Customers = _tourClientsService.GetTourClients(tour.Id);
                var Routs = _routesService.GetRoutesTour(tour.Id);
                Routs = Routs.OrderBy(x => x.Position).ToArray();
                Route routeStart = null;
                Route routeEnd = null;
                List<TransportExp> transportExp = new List<TransportExp>();
                foreach (var route in Routs)
                {
                    routeEnd = route;
                    if (!(routeStart is null))
                    {
                        AddTransport(transportExp, routeStart, routeEnd);
                    }
                    routeStart = route;
                }
                AddTransport(transportExp, routeStart, Routs[0]);
                int MaxCount = Customers.Count();
                if (MaxCount < Routs.Count()) MaxCount = Routs.Count();
                if (MaxCount < transportExp.Count()) MaxCount = transportExp.Count();
                for (int j = i; j < (MaxCount + i); j++)
                {
                    Customer cl = null;
                    City rt = null;
                    if (Customers.Count() > (j - i))
                    {
                        cl = _customersService.GetCustomer(Customers[j - i].Id_client);
                    }
                    if (Routs.Count() > (j - i))
                    {
                        rt = _citiesService.GetCity(Routs[j - i].Id_city);
                    }
                    if (cl != null)
                    {
                        sheet.Cells[j, 9] = cl.Initials;
                        sheet.Cells[j, 10] = cl.Discount;
                    }
                    if (rt != null)
                    {
                        sheet.Cells[j, 11] = Routs[j - i].Position;
                        sheet.Cells[j, 12] = rt.Name;
                        sheet.Cells[j, 13] = Routs[j - i].Price;
                    }
                    if (transportExp[j - i] != null)
                    {
                        sheet.Cells[j, 14] = transportExp[j - i].Name;
                        sheet.Cells[j, 15] = transportExp[j - i].Transport;
                        sheet.Cells[j, 16] = transportExp[j - i].Price;
                        sheet.Cells[j, 17] = transportExp[j - i].Distance;
                    }
                }
                i = i + MaxCount;
                Excel.Range sheetRange = sheet.Columns;
                sheetRange.AutoFit();
                sheet.SaveAs(sfd.FileName);
                xlApp.Quit();
                sheet = null;
                xlApp = null;
                App.ShowMessage("xlsx-документ сохранен");
            }
        }

        private void btnSpr_Click(object sender, RoutedEventArgs e)
        {
            Word.Application wordObject = new Word.Application();
            wordObject.Documents.Open(Path.GetFullPath("Sprav.docx"));
        }
    }
}
