using Pr3.Models;
using Pr3.Services;
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

namespace Pr3.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {
        int click;
        public Autho()
        {
            InitializeComponent();
            click = 0;
        }

        private void btnenterguests_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Client(null, null));
        }

        private void GenerateCapctcha()
        {
            tbCaptcha.Visibility = Visibility.Visible;
            tblCaptcha.Visibility = Visibility.Visible;

            string capctchaText = CaptchaGenerator.GenerateCaptchaText(6);
            tblCaptcha.Text = capctchaText;
            tblCaptcha.TextDecorations = TextDecorations.Strikethrough;
        }

        private void btnenter_click(object sender, RoutedEventArgs e)
        {
            click += 2;
            string login = tbLogin.Text.Trim();
            string password = tbPassword.Text.Trim();
            string hashPassw = Hash.HashPassword(password);

            РесторанEntities3 db = Helper.GetContext();

            var user = db.User.Where(x => x.Login == login && x.Password == hashPassw).FirstOrDefault();
            if (click == 1)
            {
                if (user != null)
                {
                    MessageBox.Show("Вы вошли под: " + user.Role.ToString());
                    LoadPage(user.Role.ToString(), user);
                }
                else
                {
                    MessageBox.Show("Вы ввели логин или пароль неверно!");
                    GenerateCapctcha();
                    tbPassword.Clear();
                    tblCaptcha.Visibility= Visibility.Visible;
                    tblCaptcha.Text = CaptchaGenerator.GenerateCaptchaText(6);
                }
            }
            else if (click > 1)
            {
                if (user != null && tbCaptcha.Text == tblCaptcha.Text)
                {
                    tbLogin.Clear();
                    tbPassword.Clear();
                    tblCaptcha.Text = "Text";
                    tbCaptcha.Text = "";
                    tblCaptcha.Visibility= Visibility.Hidden;
                    tbCaptcha.Visibility= Visibility.Hidden;
                    MessageBox.Show("Вы вошли под: " + user.Role.ToString());
                    LoadPage(user.Role.ToString(), user);
                }
                else
                {
                    tblCaptcha.Text = CaptchaGenerator.GenerateCaptchaText(6);
                    tbCaptcha.Text = "";
                    MessageBox.Show("Введите данные заново!");
                }
            }
        }

        private void LoadPage(string _role, User user)
        {
            click = 0;
            switch (_role)
            {
                case "Клиент":
                    NavigationService.Navigate(new Client(user, _role));
                    break;
            }
        }
    }
}

