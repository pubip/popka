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

namespace Uslygi.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddPassPage.xaml
    /// </summary>
    public partial class AddPassPage : Page
    {
        public AddPassPage()
        {
            InitializeComponent();
           // string s = SecondTextBox.Text;

        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (String.IsNullOrWhiteSpace(SecondTextBox.Text) || String.IsNullOrWhiteSpace(NameTextBox.Text) || String.IsNullOrWhiteSpace(MiddleBox.Text))
                {
                    MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (!long.TryParse(SecondTextBox.Text, out long i))
                    {
                        MessageBox.Show("Введены некорректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        if(SecondTextBox.Text.Length==10)
                        {
                            DBA.DE.AddPass(int.Parse(SecondTextBox.Text), NameTextBox.Text, MiddleBox.SelectedDate);
                            NavigationService.GoBack();
                        }
                        else
                        {
                            MessageBox.Show("Введены некорректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
