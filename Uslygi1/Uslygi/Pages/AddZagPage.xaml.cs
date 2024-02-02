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
    /// Логика взаимодействия для AddZagPage.xaml
    /// </summary>
    public partial class AddZagPage : Page
    {
        public AddZagPage()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (String.IsNullOrWhiteSpace(SecondTextBox.Text) || String.IsNullOrWhiteSpace(NameTextBox.Text) || String.IsNullOrWhiteSpace(MiddleBox.Text) || String.IsNullOrWhiteSpace(StartBox.Text) || String.IsNullOrWhiteSpace(EndBox.Text))
                {
                    MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (!int.TryParse(SecondTextBox.Text, out int i))
                    {
                        MessageBox.Show("Введены некорректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        if(SecondTextBox.Text.Length==10)
                        {
                            DBA.DE.AddZag(int.Parse(SecondTextBox.Text), NameTextBox.Text, MiddleBox.SelectedDate, StartBox.SelectedDate, EndBox.SelectedDate);
                            NavigationService.GoBack();
                        }
                        else MessageBox.Show("Введены некорректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

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
