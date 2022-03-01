using AstronomyDP;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace AstronomyWPF
{
    /// <summary>
    /// Interaction logic for Asteroids_near_Earth.xaml
    /// </summary>
    public partial class Asteroids_near_Earth : Page
    {
        public Asteroids_near_Earth()
        {
            InitializeComponent();

            var BL = new AstronomyBL.AsteroidFinder();

            var asteroids = BL.GetAsteroids();
            if (asteroids.Count > 0)
                ListViewProducts.ItemsSource = asteroids;
        }

        //private List<Asteroid> GetAsteroids()
        //{
        //    return new List<Asteroid>()
        //    {
        //        new Asteroid { Name = "ERETH", ObjectImage = @"C:\AstronomyProject\AstronomyWPF\Images\A.jpg", ID = "2376848", AbsoluteMagnitude = "2" , diameterMin = "3" , diameterMax = "4" , EpochDate = "1.2.3.4" , IsPotentiallyHazardousAsteroid = "1Yes" , IsSentryObject = "NO" , missDistance = "66" , ObjectUri = "https://ssd.jpl.nasa.gov/tools/sbdb_lookup.html#/?sstr=2363505&view=VOP", OrbitingBody = "qweqw0", Velocity = "100" }
        //    };
        //}

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var button = sender as Button;
            Asteroid currentAstroid = ((Asteroid)button.DataContext);

            sentry_current_astroid.Text = currentAstroid.IsSentryObject;
            hazardous_current_astroid.Text = currentAstroid.IsPotentiallyHazardousAsteroid;
            orbiting_body_current_astroid.Text = currentAstroid.OrbitingBody;

            id_current_astroid.Text = currentAstroid.ID;
            max_diameter_current_astroid.Text = currentAstroid.diameterMax;
            min_diameter_current_astroid.Text=currentAstroid.diameterMin;
            magnitude_current_astroid.Text = currentAstroid.AbsoluteMagnitude;
            epoch_date_current_astroid.Text = currentAstroid.EpochDate;
            miss_distance_current_astroid.Text = currentAstroid.missDistance;
            relative_velocity_current_astroid.Text = currentAstroid.Velocity;
            web_current_astroid.Text = currentAstroid.ObjectUri;
        }

        private void go_browser(object sender, System.Windows.RoutedEventArgs e)
        {
            string target = web_current_astroid.Text;
            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }
    }
}
