using AstronomyDP;
using System;
using System.Collections.Generic;
using System.Linq;
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

            calendar_picker.SelectedDate = DateTime.Now;

            var BL = new AstronomyBL.AsteroidFinder();

            var asteroids = BL.GetAsteroids();
            if (asteroids.Count > 0)
                ListViewProducts.ItemsSource = asteroids;
        }



        private void Choose_an_asteroid(object sender, System.Windows.RoutedEventArgs e)
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

        private void Select_By_Date(object sender, RoutedEventArgs e)
        {
            ListViewProducts.ItemsSource = null;
            var BL = new AstronomyBL.AsteroidFinder();
            string date = Convert.ToString(calendar_picker.SelectedDate).Split(' ')[0];

            List<Asteroid> Asteroids = BL.GetAsteroids_by_day(date);

            if (Asteroids.Count > 0)
                ListViewProducts.ItemsSource = Asteroids;

        }

        private void Select_By_Risk(object sender, RoutedEventArgs e)
        {
            ListViewProducts.ItemsSource = null;
            var BL = new AstronomyBL.AsteroidFinder();

            string selected_risk = search_risky.Text;

            List<Asteroid> Asteroids = BL.GetAsteroids_by_risk(selected_risk);
            if (Asteroids.Count > 0)
                ListViewProducts.ItemsSource = Asteroids;

            search_risky.Text = "Yes/No";
        }

        private void Select_By_Diameter(object sender, RoutedEventArgs e)
        {
            ListViewProducts.ItemsSource = null;
            var BL = new AstronomyBL.AsteroidFinder();

            string selected_Diameter = search_diameter.Text;
            float Min_Diameter = (float)Convert.ToDouble(selected_Diameter);

            List<Asteroid> Asteroids = BL.GetAsteroids_by_Diameter(Min_Diameter);

            if (Asteroids.Count > 0)
                ListViewProducts.ItemsSource = Asteroids;
        }


    }
}
