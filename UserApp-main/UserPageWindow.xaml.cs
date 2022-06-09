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
using System.Windows.Shapes;
using UserApp.Models;


namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для UserPageWindow.xaml
    /// </summary>
    public partial class UserPageWindow : Window
    {
        ApplicationContext db;
        User thisUser;
        List<Purchase> thisUserPurchases;
        List<Flight> thisUserFlights = new List<Flight>();
        List<Price> thisUserPrices = new List<Price>();
        List<FullTicket> fullTickets = new List<FullTicket>();

        public UserPageWindow(string username, string pass)
        {
            InitializeComponent();

            db = new ApplicationContext();
            thisUser = db.Users.ToList().Find(i => i.Username == username && i.Password == pass);   //Current User
            hi.Text = $"Hello, {thisUser.Username}, this is your account";

            thisUserPurchases = db.Purchases.ToList().FindAll(p => p.IDUser == thisUser.ID);  //Current User Purchases
            List<int> flightsIDs = new List<int>();
            foreach (Purchase p in thisUserPurchases)
            {
                flightsIDs.Add(p.IDFlight);
            }
  
            foreach (Purchase p in thisUserPurchases)
            {
                foreach (Flight f in db.Flights.ToList())
                {
                    if (f.ID == p.IDFlight)
                    {
                        thisUserFlights.Add(f);         //Current User Flights
                    }
                }
            }

        }

        private void ButtonLogOutClick(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Hide();
        }

        private void ButtonShowBiletsClick(object sender, RoutedEventArgs e)
        {
            

            if (thisUserFlights.Count() == 0)
            {
                nobilets.Text = "You don't have tickets yet!";
                listofbilets.ItemsSource = null;
            }
            else
            {
                foreach (Purchase p in thisUserPurchases)
                {
                    Flight f = thisUserFlights.Find(i => i.ID == p.IDFlight);
                    Price pr = db.Prices.ToList().Find(i => i.ID == p.IDPrice);
                    fullTickets.Add(new FullTicket(
                        thisUser.ID,
                        p.IDFlight,
                        p.IDPrice,
                        p.ID,
                        f.From,
                        f.To,
                        f.Departure,
                        f.Arrival,
                        f.Time,
                        pr.Type,
                        pr.Cost
                        ));
                }
                listofbilets.ItemsSource = fullTickets.ToList();
                fullTickets.Clear();
            }

            //ApplicationContext db = new ApplicationContext();

            //listofbilets.ItemsSource = db.Flights.ToList();
        }

        private void ButtonBuyClick(object sender, RoutedEventArgs e)
        {
            PurchaseWindow purchaseWindow = new PurchaseWindow(thisUser.ID);
            purchaseWindow.Show();
            this.Hide();
        }
    }

    public class FullTicket
    {
        //IDs
        public int IDUser { get; set; }
        public int IDFlight { get; set; }
        public int IDPrice { get; set; }
        public int IDPurchase { get; set; }
        //rest
        public string From { get; set; }
        public string To { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public string Time { get; set; }
        public string Type { get; set; }
        public string Price { get; set; }
        public FullTicket(int iDUser, int iDFlight, int iDPrice, int iDPurchase, 
            string from, string to, string departure, string arrival, string time, string type, string price)
        {
            //IDs
            IDUser = iDUser;
            IDFlight = iDFlight;
            IDPrice = iDPrice;
            IDPurchase = iDPurchase;
            //rest
            From = from;
            To = to;
            Departure = departure;
            Arrival = arrival;
            Time = time;
            Type = type;
            Price = price;
        }
    }

}
