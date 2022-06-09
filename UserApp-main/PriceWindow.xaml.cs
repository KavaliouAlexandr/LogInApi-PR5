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
    /// Логика взаимодействия для PriceWindow.xaml
    /// </summary>
    public partial class PriceWindow : Window
    {
        Flight flight;
        List<Price> prices;
        User user;
        public PriceWindow(int idflight, int iduser)
        {
            InitializeComponent();

            ApplicationContext db = new ApplicationContext();

            user = db.Users.ToList().Find(u => u.ID == iduser);
            flight = db.Flights.ToList().Find(f => f.ID == idflight);
            selectedFrom.Text = flight.From;
            selectedTo.Text = flight.To;
            selectedDeparture.Text = flight.Departure;
            selectedArrival.Text = flight.Arrival;


            IEnumerable<Price> IQprices = 
                from price in db.Prices
                where price.IDFlight == idflight
                select price;

            prices = IQprices.ToList();

            if (prices.Find(p => p.Type == "Economy") != null)
            {
                ecoavail.Text = "Available";
                ecoprice.Text = prices.Find(p => p.Type == "Economy").Cost.ToString();
                ecobtn.IsEnabled = true;
            }
            if (prices.Find(p => p.Type == "Premium economy") != null)
            {
                premavail.Text = "Available";
                premprice.Text = prices.Find(p => p.Type == "Premium economy").Cost.ToString();
                prembtn.IsEnabled = true;
            }
            if (prices.Find(p => p.Type == "Business class") != null)
            {
                busavail.Text = "Available";
                busprice.Text = prices.Find(p => p.Type == "Business class").Cost.ToString();
                busbtn.IsEnabled = true;
            }
            if (prices.Find(p => p.Type == "First class") != null)
            {
                frstavail.Text = "Available";
                frstprice.Text = prices.Find(p => p.Type == "First class").Cost.ToString();
                frstbtn.IsEnabled = true;
            }

        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ecobtn_Click(object sender, RoutedEventArgs e)
        {
            btnmethod("Economy");
        }
        private void prembtn_Click(object sender, RoutedEventArgs e)
        {
            btnmethod("Premium economy");
        }
        private void busbtn_Click(object sender, RoutedEventArgs e)
        {
            btnmethod("Business class");
        }
        private void frstbtn_Click(object sender, RoutedEventArgs e)
        {
            btnmethod("First class");
        }

        public void btnmethod(string cabinclass)
        {
            Purchase purchase = new Purchase(flight.ID, user.ID, prices.Find(p => p.Type == cabinclass && p.IDFlight == flight.ID).ID);
            ApplicationContext db = new ApplicationContext();
            db.Purchases.Add(purchase);
            db.SaveChanges();
            MessageBox.Show("You have successfully bought a ticket");
            this.Hide();
        }
    }
}
