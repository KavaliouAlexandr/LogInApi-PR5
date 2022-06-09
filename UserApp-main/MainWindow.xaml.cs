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

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
        }

        private void ButtonSignUpClick(object sender, RoutedEventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = passBox.Password.Trim();
            string passwordRep = passBoxRep.Password.Trim();
            string email = textBoxEmail.Text.Trim();  //.ToLower().Trim() - фильтры

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
            else if (password != passwordRep)  //---  проверка повтора пароля
            {
                passBoxRep.ToolTip = "Passwords do not match!";
                passBoxRep.Background = Brushes.DarkRed;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))  //---  проверка емейла
            {
                textBoxEmail.ToolTip = "Passwords do not match!";
                textBoxEmail.Background = Brushes.DarkRed;
            }
            else  //--- если проверка прошла успешно ---//
            {
                textBoxUsername.ToolTip = "";
                textBoxUsername.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
                passBoxRep.ToolTip = "";
                passBoxRep.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("You have successfully registered!");
                User user = new User(username, password, email);
                db.Users.Add(user);
                db.SaveChanges();
                UserPageWindow userPageWindow = new UserPageWindow(username, password);
                userPageWindow.Show();
                this.Hide();
            }

        }

        private void ButtonLogInWindowClick(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Hide();
        }

        private void ButtonClearClick(object sender, RoutedEventArgs e)
        {
            textBoxUsername.Text = "";
            passBox.Password = "";
            passBoxRep.Password = "";
            textBoxEmail.Text = "";
        }
    }
}
