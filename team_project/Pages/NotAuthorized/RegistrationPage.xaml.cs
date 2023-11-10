using Newtonsoft.Json;
using Notification.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

namespace team_project.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        ApiRequest apiRequest = new ApiRequest();
        NotificationManager notificationManager = new NotificationManager();
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private async void Button_Registration_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBox_Login.Text;
            string password = PasswordBox_Password.Password;
            string email = TextBox_Email.Text;
            string verifypassword = PasswordBox_PasswordVerify.Password;

            if (login == null || login == "" ||
                password == null || password == "" ||
                email == null || email == "" ||
                verifypassword == null || verifypassword == "")
            {
                notificationManager.Show("Заполните все поля", NotificationType.Warning);
                return;
            }

            if (password != verifypassword)
            {
                notificationManager.Show("Пароли не совпадают", NotificationType.Warning);
                return;
            }

            await apiRequest.UserRegistrationAsync(login, password, email);

            if (await apiRequest.GetLastCodeStatusAsync() == HttpStatusCode.Created)
            {
                this.NavigationService.GoBack();
               
            }
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
