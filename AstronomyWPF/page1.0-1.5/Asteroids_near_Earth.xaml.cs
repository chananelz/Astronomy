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

        private List<Star> GetProducts()
        {
            return new List<Star>()
            {
                new Star { Name = "ERETH", ObjectImage = @"C:\AstronomyProject\AstronomyWPF\Images\A.jpg" },
                new Star { Name = "ERETH", ObjectImage = @"C:\AstronomyProject\AstronomyWPF\Images\A.jpg" },
                new Star { Name = "ERETH", ObjectImage = @"C:\AstronomyProject\AstronomyWPF\Images\A.jpg" },
                new Star { Name = "ERETH", ObjectImage = @"C:\AstronomyProject\AstronomyWPF\Images\A.jpg" }
            };
        }
    }
}
