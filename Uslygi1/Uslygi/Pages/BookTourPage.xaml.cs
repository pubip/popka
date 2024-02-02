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
using System.Net.Mail;


namespace Uslygi.Pages
{
    /// <summary>
    /// Логика взаимодействия для BookTourPage.xaml
    /// </summary>
    
    public partial class BookTourPage : Page
    {

        TourInfo touri;
        Worker worker;
        Client clients;
        double sum;
        string header = "           Турагенство Вояж           \n                        РАДЫ ВАС ПРИВЕТСТВОВАТЬ!                        \nКАССОВЫЙ ЧЕК/ПРИХОД\n";
        string worker1 = "НОМЕР СМЕНЫ ";
        string order = "НОМЕР ЧЕКА ";
        string middle = "\nПОЛНЫЙ РАСЧЕТ\n";
        string products = "    "; 
        string sum1 = "ИТОГ                              =";
        string last = "\n           СПАСИБО ЗА ПОКУПКУ!           "; 
        check check2;
        string cheque; string orderdate = "";
        double sumOrder = 0;


        public BookTourPage(TourInfo tour, Worker w)
        {
            InitializeComponent();
            touri = tour;
            worker = w;
            DateTime dt = DateTime.Now;
            clients = DBA.DE.Client.OrderByDescending(x => x.ClientId).ToList()[0];
            int checkid = DBA.DE.check.OrderByDescending(x => x.CheckId).ToList()[0].CheckId;
             sum = (double)tour.CountPrice;
            if (clients.IdVidClient != 1)
            {
                sum *= 0.85;
            }
            checkt.Text = header + worker1 + w.WorkerId + "\n" + order + checkid + "\n" + middle + products + tour.TourName + "\n" + tour.CountPrice + "\n" + sum1 + sum + "\n" + last;
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {


            var result1 = System.Windows.MessageBox.Show("Отправить чек клиенту по E-mail?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result1 == MessageBoxResult.Yes)
            {
                try
                {
                    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                    SmtpClient mySmtpClient = new SmtpClient("smtp.mail.ru");
                    mySmtpClient.Port = 587;
                    mySmtpClient.UseDefaultCredentials = true;
                    mySmtpClient.EnableSsl = true;

                    System.Net.NetworkCredential basicAuthenticationInfo = new
                       System.Net.NetworkCredential("purple_nigga@mail.ru", "NagiB90C");
                    mySmtpClient.Credentials = basicAuthenticationInfo;
                    MailAddress from = new MailAddress("purple_nigga@mail.ru", "Турагенство Вояж");
                    MailAddress to;
                    string forClient = $"{clients.ClientName} {clients.ClientMiddleName}";
                    to = new MailAddress(clients.ClientEmail, forClient);

                    MailMessage myMail = new MailMessage(from, to);
                   
                    MailAddress replyTo = new MailAddress("purple_nigga@mail.ru");
                    myMail.ReplyToList.Add(replyTo);

                    // set subject and encoding
                    myMail.Subject = "Чек";
                    myMail.SubjectEncoding = System.Text.Encoding.UTF8;
                    myMail.Body = $"<p>Здравствуйте, {forClient}!</p><p>Вот ваш чек.</p><p>Оформил: {worker.WorkerSecondName} {worker.WorkerName[0]}.{worker.WorkerMiddleName[0]}</p><p>Cумма: {sum} </p><p>По всем вопросам обращаться: + 7 777 777 77 77</p>";
                    myMail.BodyEncoding = Encoding.UTF8;
                    // text or html
                    myMail.IsBodyHtml = true;

                    mySmtpClient.Send(myMail);
                }
                catch (SmtpException ex)
                {
                    System.Windows.MessageBox.Show("При отправке произошла ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                }
            }

        private void TicketButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TicketPage(touri, worker));
        }

        private void bbbutton_Click(object sender, RoutedEventArgs e)
        {
            //worker = w;
            NavigationService.Navigate(new Allproducts(worker));
        }
    }
}
