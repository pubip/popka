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
    /// Логика взаимодействия для Deal.xaml
    /// </summary>
    public partial class DealPage : Page
    {
        Worker worker;


        public DealPage(Worker w)
        {
            InitializeComponent();
            CountryComboBox.ItemsSource = DBA.DE.Country.ToList();
            CityComboBox.ItemsSource = DBA.DE.City.ToList();
            HotelComboBox.ItemsSource = DBA.DE.Hotel.ToList();
            TypeTourComboBox.ItemsSource = DBA.DE.TypeTour.ToList();
            VidTourComboBox.ItemsSource = DBA.DE.VidTour.ToList();
            AvaliabilityComboBox.ItemsSource = DBA.DE.Availability.ToList();
            worker = w;

        }
        //добавить.изменить
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CountryComboBox.ItemsSource = DBA.DE.Country.ToList();
            CityComboBox.ItemsSource = DBA.DE.City.ToList();
            HotelComboBox.ItemsSource = DBA.DE.Hotel.ToList();
            TypeTourComboBox.ItemsSource = DBA.DE.TypeTour.ToList();
            VidTourComboBox.ItemsSource = DBA.DE.VidTour.ToList();
            AvaliabilityComboBox.ItemsSource = DBA.DE.Availability.ToList();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            //try
            //{
                Country z1 = CountryComboBox.SelectedItem as Country;
                City x1 = CityComboBox.SelectedItem as City;
                Hotel c1 = HotelComboBox.SelectedItem as Hotel;
                TypeTour v1 = TypeTourComboBox.SelectedItem as TypeTour;
                VidTour b1 = VidTourComboBox.SelectedItem as VidTour;
                Availability n1 = AvaliabilityComboBox.SelectedItem as Availability;

                if (String.IsNullOrWhiteSpace(SecondTextBox.Text) || String.IsNullOrWhiteSpace(NameTextBox.Text) || String.IsNullOrWhiteSpace(DescBox.Text) || String.IsNullOrWhiteSpace(Nights.Text) ||  String.IsNullOrWhiteSpace(StartBox.Text) || String.IsNullOrWhiteSpace(EndBox.Text) || z1 == null || x1 == null || c1 == null || b1 == null || n1 == null || String.IsNullOrWhiteSpace(PriceBox.Text))

                { 
                    MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {

                    Country z = CountryComboBox.SelectedItem as Country;
                    City x = CityComboBox.SelectedItem as City;
                    Hotel c = HotelComboBox.SelectedItem as Hotel;
                    TypeTour v = TypeTourComboBox.SelectedItem as TypeTour;
                    VidTour b = VidTourComboBox.SelectedItem as VidTour;
                    Availability n = AvaliabilityComboBox.SelectedItem as Availability;
                    DBA.DE.AddTour(SecondTextBox.Text, NameTextBox.Text, int.Parse(DescBox.Text), int.Parse(Nights.Text), "", StartBox.SelectedDate, EndBox.SelectedDate, z.CountryId, x.CityId, c.HotelId, v.TypeTourId, b.VidTourId, n.AvailabilityId, int.Parse(PriceBox.Text));
                    NavigationService.Navigate(new Pages.Allproducts(worker));


                }
            //}
            //catch
            //{
            //    MessageBox.Show("Что-то пошло не так", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            
        }
    }
}
