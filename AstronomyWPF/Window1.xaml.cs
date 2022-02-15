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

namespace AstronomyWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            //Application.Current.Shutdown();

            frame.Navigate(new Uri(@"page1.0-1.5\Explanation0.xaml", UriKind.RelativeOrAbsolute));
        }


        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void SideMenuControl_SelectionChanged(object sender, EventArgs e)
        {
            switch (ListViewMenu.SelectedIndex)
            {
                case 0:
                    frame.Navigate(new Uri(@"page1.0-1.5\Explanation0.xaml", UriKind.RelativeOrAbsolute));
                    break;
                case 1:
                    frame.Navigate(new Uri(@"page1.0-1.5\Picture_of_the_Day.xaml", UriKind.RelativeOrAbsolute));
                    break;
                case 2:
                    frame.Navigate(new Uri(@"page1.0-1.5\Planet_Profiles.xaml", UriKind.RelativeOrAbsolute));
                    break;
                case 3:
                    frame.Navigate(new Uri(@"page1.0-1.5\media_search.xaml", UriKind.RelativeOrAbsolute));
                    break;
                case 4:
                    frame.Navigate(new Uri(@"page1.0-1.5\Asteroids_near_Earth.xaml", UriKind.RelativeOrAbsolute));
                    break;

            }
        }
    }

}

