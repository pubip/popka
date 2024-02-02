using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    /// Логика взаимодействия для TicketPage.xaml
    /// </summary>
    public partial class TicketPage : Page
    {
        TourInfo t;
        Worker worker;
        Client clients;
        double sum;
        public TicketPage(TourInfo tour, Worker w)
        {
            InitializeComponent();
            t = tour;
            worker = w;
            check check1 = DBA.DE.check.OrderByDescending(x => x.CheckDate).ToList()[0];
            clients = DBA.DE.Client.OrderByDescending(x => x.ClientId).ToList()[0];

            DateTime dt = (DateTime)check1.CheckDate;

            DateTextBlock.Text += dt.ToShortDateString();

            int checkid = DBA.DE.check.OrderByDescending(x => x.CheckId).ToList()[0].CheckId;
            NumcTextBlock.Text += checkid;

            TourAgentTextBlock.Text = clients.ClientSecondName + " " + clients.ClientName + " " + clients.ClientMiddleName;
            WorkTextBlock.Text = worker.WorkerSecondName + " " + worker.WorkerName + " " + worker.WorkerMiddleName;
            Country1.Text = t.CountryName;
            Hotel1.Text = t.HotelName;
            sum = (double)tour.CountPrice;
            if (clients.IdVidClient != 1)
            {
                sum *= 0.85;
            }
            price1.Text = sum.ToString();
            PriceBox.Text = sum.ToString();
            Nightsblock.Text = t.AmountOfNights.ToString();
            Peopleblock.Text = t.AmountOfPeople.ToString();
            DatesText.Text = t.FormatDate; 
            NumTextBlock.Text = tour.TourId.ToString();
            NameTextBlock.Text = tour.TourName.ToString();
            HotelText.Text = t.FormatHotel;
            Descrt.Text = tour.TourDescription.ToString();
            seria.Text = clients.PassportId.ToString();
            kemv.Text = clients.Pass.PassportLocation.ToString();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            var helper = new WordHelper("Тур. Вояж. Чек.docx");
            var items = new Dictionary<string, string>
                    {
                        {   "<ticket>", NumcTextBlock.Text},
                        {   "<FIO>", TourAgentTextBlock.Text},
                        {   "<date>", DateTextBlock.Text},
                        {   "<NumT>", NumTextBlock.Text},
                        {   "<NameT>", NameTextBlock.Text},
                        {   "<NumP>", Peopleblock.Text},
                        {   "<nights>", Nightsblock.Text},
                        {   "<Descp>", Descrt.Text},
                        {   "<SE>", DatesText.Text},
                        {   "<H>", HotelText.Text},
                        { "<price>", PriceBox.Text},
                        

                    };
            helper.Process(items);
            NavigationService.Navigate(new Pages.BookTourPage(t, worker));           
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Dog_Click(object sender, RoutedEventArgs e)
        {
            var helper = new WordHelper("Тур. Вояж. Договор.docx");
            var items = new Dictionary<string, string>
                    {
                        {   "<ticket>", NumcTextBlock.Text},
                        {   "<FIO>", TourAgentTextBlock.Text},
                        {   "<date>", DateTextBlock.Text},
                        {   "<NumT>", NumTextBlock.Text},
                        {   "<NameT>", NameTextBlock.Text},
                        {   "<NumP>", Peopleblock.Text},
                        {   "<nights>", Nightsblock.Text},
                        {   "<Descp>", Descrt.Text},
                        {   "<SE>", DatesText.Text},
                        {   "<H>", HotelText.Text},
                        {   "<FIO1>", WorkTextBlock.Text},
                        {"<C>", Country1.Text },
                        {"<H1>", Hotel1.Text },
                        {"<sum>", price1.Text},
                        {"<serian>", seria.Text},
                        {"<kemv>", kemv.Text},
                    };
            helper.Process(items);
        }
    }
}
