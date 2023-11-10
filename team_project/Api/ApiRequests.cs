using Newtonsoft.Json;
using Notification.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using team_project.Model;

namespace team_project
{
    internal class ApiRequest
    {
        public static string ERROR_authorization = "Неверные данные";
        public static string ERROR_not_authorized = "Токен не действителен";
        public static string ERROR_forbidden = "Нет доступа к этому действию";
        public static string ERROR_null = "Список пуст";
        public static string STATUS_success = "Успешно";
        static NotificationManager notificationManager = new NotificationManager();

        public HttpStatusCode current_status;
        static HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:8080/")
        };

        public ApiRequest()
        {
            current_status = new HttpStatusCode();
        }
        public async Task UserRegistrationAsync(string login, string password, string email)
        {
            RegistrationModel registrationModel = new RegistrationModel()
            {
                email = email,
                password = password,
                login = login,
            };

            var json = JsonConvert.SerializeObject(registrationModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("Registration", data);
            current_status = response.StatusCode;

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                notificationManager.Show(title: "Регистрация", message: STATUS_success, NotificationType.Success);
            }
            else
            {
                notificationManager.Show(title: "Регистрация", message: $"{response.Content.ReadAsStringAsync().Result}", NotificationType.Error);
            }
        }
        public async Task<string> UserLoginAsync(string login, string password)
        {
            string token = String.Empty;
            LoginModel loginModel = new LoginModel()
            {
                login = login,
                password = password,
            };

            var json = JsonConvert.SerializeObject(loginModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("Login", data);
            current_status = response.StatusCode;

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            { 
                notificationManager.Show(title: "Вход", message: ERROR_authorization, NotificationType.Error);
                return String.Empty;
            }
            else
            {
                notificationManager.Show(title: "Вход", message: "Успешно", NotificationType.Success);
                token = response.Content.ReadAsStringAsync().Result;
                return token;
            }
        }
        /// <summary>
        /// Token добавляется к httpclient и записывается в static поле.
        /// По токену получаем информацию о пользоваетеле через метод в api
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task SetTokenForClientAsync(string token)
        {
            if (token == null || token == "")
            {
                notificationManager.Show(title: "Вход", message: ERROR_not_authorized, NotificationType.Error);    
            }
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync("User/GetCurrentUserInfo");
            current_status =  response.StatusCode;


            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                User user = JsonConvert.DeserializeObject<User>(response.Content.ReadAsStringAsync().Result);
                CurrentUser.token = token;
                CurrentUser.IdUser = user.idUser;
            }
            else
            {
                notificationManager.Show(title: "Вход", message: ERROR_not_authorized, NotificationType.Error);
            }
        }
        public async Task<List<Library>> GetProducts()
        {
            List<Library> products = new List<Library>();

            if (CurrentUser.token == null)
            {
                notificationManager.Show(title: "Аутентификация", message: ERROR_not_authorized, NotificationType.Error);
                return products;
            }

            var response = await client.GetAsync($"Library/{CurrentUser.IdUser}");

            products = JsonConvert.DeserializeObject<List<Library>>(response.Content.ReadAsStringAsync().Result);
            MessageBox.Show(response.Content.ReadAsStringAsync().Result);

            return products;
        }
        public void ClearUserInfo()
        {
            CurrentUser.token = "";
            CurrentUser.IdUser = 0;
            client = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:8080/")
            };
        }
        public async Task<HttpStatusCode> GetLastCodeStatusAsync()
        {
            return current_status;
        }
    }
}
