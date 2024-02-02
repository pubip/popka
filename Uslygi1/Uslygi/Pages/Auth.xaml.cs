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
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            String Login = LoginBox.Text;
            String Password = PasswordBox.Password;
            Worker worker = DBA.DE.Worker.FirstOrDefault(c => c.Login == Login && c.Password == Password);
            if (worker != null)
            {
                NavigationService.Navigate(new Allproducts(worker));

            }
        }

        private void LoginBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
