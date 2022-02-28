using AstronomyDP;
using System.Collections.Generic;
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
            var products = GetProducts();
            if (products.Count > 0)
                ListViewProducts.ItemsSource = products;
        }

        private List<Asteroid> GetProducts()
        {
            return new List<Asteroid>()
            {
                new Asteroid { Name = "ERETH", ObjectImage = @"C:\AstronomyProject\AstronomyWPF\Images\A.jpg", ID = "2376848", AbsoluteMagnitude = "2" , diameterMin = "3" , diameterMax = "4" , EpochDate = "1.2.3.4" , IsPotentiallyHazardousAsteroid = "Yes" , IsSentryObject = "NO" , missDistance = "66" , ObjectUri = "https://ssd.jpl.nasa.gov/tools/sbdb_lookup.html#/?sstr=2363505&view=VOP", OrbitingBody = "qweqw0", Velocity = "100" }
            };
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var button = sender as Button;
            Asteroid currentAstroid = ((Asteroid)button.DataContext);
            sentry_current_astroid.Text = currentAstroid.diameterMin;
        }
    }
}
