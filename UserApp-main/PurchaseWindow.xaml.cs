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
    /// Логика взаимодействия для PurchaseWindow.xaml
    /// </summary>
    public partial class PurchaseWindow : Window
    {
        User user;
        public PurchaseWindow(int id)
        {
            InitializeComponent();
            ApplicationContext db = new ApplicationContext();
            user = db.Users.ToList().Find(u => u.ID == id);
            usernamebutton.Content = user.Username;
            countTickets.Text = "Number of results: " + db.Flights.Count().ToString();
            listofFlights.ItemsSource = db.Flights.ToList();
        }

        private void ButtonAcoountClick(object sender, RoutedEventArgs e)
        {
            UserPageWindow userPageWindow = new UserPageWindow(user.Username, user.Password);
            userPageWindow.Show();
            this.Hide();
        }

        private void ButtonBuyClick(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(sender.ToString().Split(' ')[1]);

            PriceWindow priceWindow = new PriceWindow(id, user.ID );
            priceWindow.Show();
        }
    }
}
