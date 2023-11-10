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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using team_project.Pages.UserPages;

namespace team_project.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            UserFrame.NavigationService.Navigate(new UserLibraryPage());
        }

        private void Button_MenuOverlay_Click(object sender, RoutedEventArgs e)
        {
            if (OverlayFrame.Content != null)
            {
                OverlayFrame.NavigationService.RemoveBackEntry();
                OverlayFrame.Content = null;
            }
            else
            {
                OverlayFrame.Navigate(new OverlayPage());
                
            }
            
        }

        private void OverlayFrame_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
/*            if (OverlayFrame.Content == null)
            {
                OverlayFrame.Navigate(new OverlayPage());
            }*/

        }

        private void OverlayFrame_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            if (e.Content != null)
            {
                var ta = new ThicknessAnimation();
                ta.Duration = TimeSpan.FromSeconds(0.3);
                ta.DecelerationRatio = 0.7;
                ta.To = new Thickness(0, 0, 0, 0);
                if (e.NavigationMode == NavigationMode.New)
                {
                    ta.From = new Thickness(-500, 0, 0, 0);
                    (e.Content as Page).BeginAnimation(MarginProperty, ta);
                }
                else
                {
                    ta.From = new Thickness(0, 0, -500, 0);
                    (e.Content as Page).BeginAnimation(MarginProperty, ta);

                    OverlayFrame.NavigationService.RemoveBackEntry();
                    OverlayFrame.Content = null;
                }
                 
            }
                
        }
    }
}
