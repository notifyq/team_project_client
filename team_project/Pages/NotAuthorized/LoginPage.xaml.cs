using Newtonsoft.Json;
using Notification.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using team_project.Model;
using team_project.Windows;

namespace team_project.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        NotificationManager notificationManager = new NotificationManager();
        
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Registration_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegistrationPage());
        }

        private async void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBox_Login.Text;
            string password = PasswordBox_Password.Password;

            if (login == null || login == "" || password == null || password == "")
            {
                notificationManager.Show("Заполните все поля", NotificationType.Warning);
                return;
            }
            else
            {
                ApiRequest apiRequest = new ApiRequest();
                string token = await apiRequest.UserLoginAsync(login, password);
                await apiRequest.SetTokenForClientAsync(token);

                Application.Current.MainWindow.Close();

                UserWindow userWindow = new UserWindow();
                userWindow.Show();

                
            }
        }
    }
}
