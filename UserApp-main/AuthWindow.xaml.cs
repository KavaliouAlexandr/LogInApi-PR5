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

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void ButtonLogInClick(object sender, RoutedEventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = passBox.Password.Trim();

            if (username.Length < 5)   //---  проверка логина
            {
                textBoxUsername.ToolTip = "This field is entered incorrectly!";   //подсказка когда наводишь мышью
                textBoxUsername.Background = Brushes.DarkRed;
            }
            else if (password.Length < 5)  //---  проверка пароля
            {
                passBox.ToolTip = "This field is entered incorrectly!";
                passBox.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxUsername.ToolTip = "";
                textBoxUsername.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                User authUser = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.Where(b => b.Username == username &&
                        b.Password == password).FirstOrDefault();
                }

                if (authUser != null)
                {
                    MessageBox.Show("You have successfully logged in!");
                    UserPageWindow userPageWindow = new UserPageWindow(username, password);
                    userPageWindow.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("You entered something incorrectly!");
                }
            }
        }

        private void ButtonSignInWindowClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void ButtonClearClick(object sender, RoutedEventArgs e)
        {
            textBoxUsername.Text = "";
            passBox.Password = "";
        }
    }
}
