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
using team_project.Windows;

namespace team_project.Pages.UserPages
{
    /// <summary>
    /// Логика взаимодействия для OverlayPage.xaml
    /// </summary>
    public partial class OverlayPage : Page
    {
        Window mainWindow;
        Frame UserFrame;
        public OverlayPage()
        {
            InitializeComponent();
        }

        private void Button_Library_Click(object sender, RoutedEventArgs e)
        {
            UserFrame.NavigationService.Navigate(new UserLibraryPage());
        }

        private void Button_SupportService_Click(object sender, RoutedEventArgs e)
        {
            UserFrame.NavigationService.Navigate(new UserSupportServicePage());
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.ClearUserInfo();

            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            mainWindow.Close();
        }

        public void LoadCurrentWindow()
        {
            mainWindow = Window.GetWindow(this);
            UserFrame = mainWindow.FindName("UserFrame") as Frame;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCurrentWindow();
        }
    }
}
