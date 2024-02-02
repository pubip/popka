using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Allproducts.xaml
    /// </summary>
    public partial class Allproducts : Page
    {
        Worker worker;

        
        public Allproducts(Worker w)
        {
            InitializeComponent();
            AllClientView.ItemsSource = DBA.DE.TourInfo.ToList();
            WorkerTextBlock.Text = w.WorkerSecondName + " " + w.WorkerName + " " + w.WorkerMiddleName;
            worker = w;
            
        }

        //поиск
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                var search = DBA.DE.TourInfo.Where(x => x.TourName.ToLower().Contains(SearchTextBox.Text.ToLower()) || x.TypeTourName.ToLower().Contains(SearchTextBox.Text.ToLower()) || x.VidTourName.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
                if (search.Count == 0)
                {
                    MessageBox.Show("Такого тура нет!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                    SearchTextBox.Clear();
                    AllClientView.ItemsSource = DBA.DE.TourInfo.ToList();

                }
                else
                {
                    AllClientView.ItemsSource = search;
                }
            }
            else
            {
                AllClientView.ItemsSource = DBA.DE.TourInfo.ToList();
            }
        }

        //сортировка
        private void SortCost_Checked(object sender, RoutedEventArgs e)
        {
           AllClientView.ItemsSource = DBA.DE.TourInfo.OrderBy(x => x.AmountOfNights).ToList();
        }

        private void CancelSort_Click(object sender, RoutedEventArgs e)
        {
            SortCost.IsChecked = false;
            SortPeople.IsChecked = false;
            AllClientView.ItemsSource = DBA.DE.TourInfo.ToList();
        }

       
        
        //добавить.изменить
        

        private void Deal_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DealPage(worker));
        }

        private void SortPeople_Checked(object sender, RoutedEventArgs e)
        {
            AllClientView.ItemsSource = DBA.DE.TourInfo.OrderBy(x => x.AmountOfPeople).ToList();
        }


        private void BuyTourButton_Click(object sender, RoutedEventArgs e)
        {
            var Img = sender as Button;
            var SelectedProduct = Img.DataContext as TourInfo;
            if (SelectedProduct != null)
            {
                NavigationService.Navigate(new AddClientPage(SelectedProduct, worker));
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AllClientView.ItemsSource = DBA.DE.TourInfo.ToList();
        }

        private void DeleteTourButton_Click(object sender, RoutedEventArgs e)
        {
            var Img = sender as Button;
            var SelectedProduct = Img.DataContext as TourInfo;
            if (SelectedProduct != null)
            {
                DBA.DE.DeleteTour(SelectedProduct.TourId);
                AllClientView.ItemsSource = DBA.DE.TourInfo.ToList();
            }
        }
    }
}
