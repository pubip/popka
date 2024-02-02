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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Uslygi.Classes;
using Uslygi.Databases;

namespace Uslygi.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        TourInfo tourInfo;
        Worker worker;
        public AddClientPage(TourInfo tour, Worker w)
        {
            InitializeComponent();
            VidComboBox.ItemsSource = DBA.DE.VidClient.ToList();
            PassComboBox.ItemsSource = DBA.DE.Pass.ToList();
            ZagComboBox.ItemsSource = DBA.DE.Zag.ToList();
            worker = w;
            tourInfo = tour;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VidClient v1 = VidComboBox.SelectedItem as VidClient;
                Pass pass = PassComboBox.SelectedItem as Pass;
                Zag z1 = ZagComboBox.SelectedItem as Zag;

                if (String.IsNullOrWhiteSpace(SecondTextBox.Text) || String.IsNullOrWhiteSpace(NameTextBox.Text) || String.IsNullOrWhiteSpace(MiddleBox.Text) || v1==null || pass == null || z1 == null || String.IsNullOrWhiteSpace(MailBox.Text))
                {
                    MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {

                    VidClient v = VidComboBox.SelectedItem as VidClient;
                    Pass p = PassComboBox.SelectedItem as Pass;
                    Zag z = ZagComboBox.SelectedItem as Zag;
                    if(z.ZagranId.ToString().Length == 10 && p.PassportId.ToString().Length == 10)
                    {
                        DBA.DE.AddClient(SecondTextBox.Text, "", NameTextBox.Text, MiddleBox.Text, v.IdVidClient, p.PassportId, z.ZagranId, MailBox.Text);
                        int clientid = DBA.DE.Client.OrderBy(x => x.ClientId).ToList()[0].ClientId;
                        DBA.DE.AddCheck(clientid, worker.WorkerId, tourInfo.TourId);
                        NavigationService.Navigate(new Pages.TicketPage(tourInfo, worker));
                    }
                    else MessageBox.Show("Паспортные данные недействительны", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddPassButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddPassPage());

        }

        private void AddzagButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddZagPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            VidComboBox.ItemsSource = DBA.DE.VidClient.ToList();
            PassComboBox.ItemsSource = DBA.DE.Pass.ToList();
            ZagComboBox.ItemsSource = DBA.DE.Zag.ToList();
        }

        private void VidComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
