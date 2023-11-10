using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace team_project
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ButtonMouseEnter(object sender, MouseEventArgs e)
        {
            var brush = Application.Current.Resources["ButtonMouseEnter"] as SolidColorBrush;
            ((Border)sender).Background = brush;
        }

        private void ButtonMouseLeave(object sender, MouseEventArgs e)
        {
            var brush = Application.Current.Resources["ButtonMouseLeave"] as SolidColorBrush;
            ((Border)sender).Background = brush;
        }

        private void ButtonBackgound_MouseEnter(object sender, MouseEventArgs e)
        {
            var brush = Application.Current.Resources["ButtonOverlayMouseEnter"] as SolidColorBrush;
            ((Border)sender).Background = brush;
        }

        private void ButtonBackgound_MouseLeave(object sender, MouseEventArgs e)
        {
            var brush = Application.Current.Resources["ButtonOverlayMouseLeave"] as SolidColorBrush;
            ((Border)sender).Background = brush;
        }
    }
}
