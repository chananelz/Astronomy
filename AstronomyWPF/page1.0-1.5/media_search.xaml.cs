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

namespace AstronomyWPF
{
    /// <summary>
    /// Interaction logic for media_search.xaml
    /// </summary>
    public partial class media_search : Page
    {
        public media_search()
        {
            InitializeComponent();
        }

        private void GetEarthInfo(object sender, RoutedEventArgs e)
        {
            var BL = new AstronomyBL.InformationAboutPlanetFinder();

            List <String>  urls = BL.Get_information_about_planet_finder("Earth");

            photos1.Source = new BitmapImage(new Uri(urls[0]));
            photos2.Source = new BitmapImage(new Uri(urls[1]));
            photos3.Source = new BitmapImage(new Uri(urls[2]));
            photos4.Source = new BitmapImage(new Uri(urls[3]));
            photos5.Source = new BitmapImage(new Uri(urls[4]));
            photos6.Source = new BitmapImage(new Uri(urls[5]));
            photos7.Source = new BitmapImage(new Uri(urls[6]));
            photos8.Source = new BitmapImage(new Uri(urls[7]));
            photos9.Source = new BitmapImage(new Uri(urls[8]));



        }

        private void GetMercuryInfo(object sender, RoutedEventArgs e)
        {
            var BL = new AstronomyBL.InformationAboutPlanetFinder();

            List<String> urls = BL.Get_information_about_planet_finder("Mercury");

            photos1.Source = new BitmapImage(new Uri(urls[0]));
            photos2.Source = new BitmapImage(new Uri(urls[1]));
            photos3.Source = new BitmapImage(new Uri(urls[2]));
            photos4.Source = new BitmapImage(new Uri(urls[3]));
            photos5.Source = new BitmapImage(new Uri(urls[4]));
            photos6.Source = new BitmapImage(new Uri(urls[5]));
            photos7.Source = new BitmapImage(new Uri(urls[6]));
            photos8.Source = new BitmapImage(new Uri(urls[7]));
            photos9.Source = new BitmapImage(new Uri(urls[8]));

        }

        private void GetVenusInfo(object sender, RoutedEventArgs e)
        {
            var BL = new AstronomyBL.InformationAboutPlanetFinder();

            List<String> urls = BL.Get_information_about_planet_finder("Venus");

            photos1.Source = new BitmapImage(new Uri(urls[0]));
            photos2.Source = new BitmapImage(new Uri(urls[1]));
            photos3.Source = new BitmapImage(new Uri(urls[2]));
            photos4.Source = new BitmapImage(new Uri(urls[3]));
            photos5.Source = new BitmapImage(new Uri(urls[4]));
            photos6.Source = new BitmapImage(new Uri(urls[5]));
            photos7.Source = new BitmapImage(new Uri(urls[6]));
            photos8.Source = new BitmapImage(new Uri(urls[7]));
            photos9.Source = new BitmapImage(new Uri(urls[8]));



        }

        private void GetMarsInfo(object sender, RoutedEventArgs e)
        {
            var BL = new AstronomyBL.InformationAboutPlanetFinder();

            List<String> urls = BL.Get_information_about_planet_finder("Mars");

            photos1.Source = new BitmapImage(new Uri(urls[0]));
            photos2.Source = new BitmapImage(new Uri(urls[1]));
            photos3.Source = new BitmapImage(new Uri(urls[2]));
            photos4.Source = new BitmapImage(new Uri(urls[3]));
            photos5.Source = new BitmapImage(new Uri(urls[4]));
            photos6.Source = new BitmapImage(new Uri(urls[5]));
            photos7.Source = new BitmapImage(new Uri(urls[6]));
            photos8.Source = new BitmapImage(new Uri(urls[7]));
            photos9.Source = new BitmapImage(new Uri(urls[8]));
        }

        private void GetJupiterInfo(object sender, RoutedEventArgs e)
        {
            var BL = new AstronomyBL.InformationAboutPlanetFinder();

            List<String> urls = BL.Get_information_about_planet_finder("Jupiter");

            photos1.Source = new BitmapImage(new Uri(urls[0]));
            photos2.Source = new BitmapImage(new Uri(urls[1]));
            photos3.Source = new BitmapImage(new Uri(urls[2]));
            photos4.Source = new BitmapImage(new Uri(urls[3]));
            photos5.Source = new BitmapImage(new Uri(urls[4]));
            photos6.Source = new BitmapImage(new Uri(urls[5]));
            photos7.Source = new BitmapImage(new Uri(urls[6]));
            photos8.Source = new BitmapImage(new Uri(urls[7]));
            photos9.Source = new BitmapImage(new Uri(urls[8]));

        }


    }
}
