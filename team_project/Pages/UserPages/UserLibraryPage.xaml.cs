using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace team_project.Pages.UserPages
{
    /// <summary>
    /// Логика взаимодействия для UserDefaultPage.xaml
    /// </summary>
    public partial class UserLibraryPage : Page
    {
        public UserLibraryPage()
        {
            InitializeComponent();
            LoadProductsAsync();
        }

        public async void LoadProductsAsync()
        {
            ApiRequest apiRequest = new ApiRequest();
            List<Library> products = await apiRequest.GetProducts();
            LibraryListView.ItemsSource = products;
        }
    }
}
