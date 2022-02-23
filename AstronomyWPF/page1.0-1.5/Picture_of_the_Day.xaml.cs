﻿using System;
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
    /// Interaction logic for Picture_of_the_Day.xaml
    /// </summary>
    public partial class Picture_of_the_Day : Page
    {
        public Picture_of_the_Day()
        {
            InitializeComponent();
            var BL = new AstronomyBL.PictureOfTheDayFinder();
            image_today.Source = new BitmapImage(new Uri(BL.Get_today_picture_of_the_day()));
        }
        private void Show_Picture(object sender, RoutedEventArgs e)
        {
            var date = Convert.ToString(calendar_picker.SelectedDate).Split(' ')[0];
            var BL = new AstronomyBL.PictureOfTheDayFinder();

            string url_picture_of_the_day = BL.Get_picture_of_the_day_By_day(date)[0].Url;
            image_today.Source = new BitmapImage(new Uri(url_picture_of_the_day));
        }
    }
}
