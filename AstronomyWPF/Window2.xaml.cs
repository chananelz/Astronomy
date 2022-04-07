using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.IO;
using FireSharp.Interfaces;
using Microsoft.Maps.MapControl.WPF;

namespace AstronomyWPF
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        FileStream stream;
        IFirebaseConfig fc = new FireSharp.Config.FirebaseConfig
        {
            AuthSecret = "gPqWPJP1H6zF7bZo1jQf5ax91slhGLmdPSY8fuvt",
            BasePath = "https://fir-astronomy-default-rtdb.firebaseio.com/"
        };
        public Window2()
        {
            InitializeComponent();
        }
        public bool ThumbnailCallback()
        {
            return false;
        }

        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        private void MapWithPushpins_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Disables the default mouse double-click action.
            e.Handled = true;

            //Get the mouse click coordinates
            var mousePosition = e.GetPosition(MyMap);

            //Convert the mouse coordinates to a locatoin on the map
            Location pinLocation = MyMap.ViewportPointToLocation(mousePosition);

            // The pushpin to add to the map.
            Pushpin pin = new Pushpin();
            pin.Location = pinLocation;
            longitude.Text = pinLocation.Longitude.ToString().Substring(0, 7);
            latitude.Text = pinLocation.Latitude.ToString().Substring(0, 7);

            // Adds the pushpin to the map.
            MyMap.Children.Clear();
            MyMap.Children.Add(pin);
            
        }

        private  void Button_uplode_image(object sender, RoutedEventArgs e)
        {


            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image Files(*.jpg) | *.jpg";

            if (ofd.ShowDialog() == true)
            {
                Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                Bitmap myBitmap = new Bitmap(ofd.FileName);
                pictureBox.Source = BitmapToImageSource((Bitmap)myBitmap.GetThumbnailImage(240, 161, null, new IntPtr()));
                myBitmap.Dispose();
                stream = File.Open(ofd.FileName, FileMode.Open);
            }
        }

        private void Button_message(object sender, RoutedEventArgs e)
        {
            if (hidden_messgebox.Visibility == Visibility.Hidden)
            {
                hidden_messgebox.Visibility = Visibility.Visible;
            }
            else
            {
                var BL = new AstronomyBL.firebase.SendMessage();
                bool result = BL.sendEncryptedMessage(hidden_messgebox.Text);
                hidden_messgebox.Text = "";
                hidden_messgebox.Visibility = Visibility.Hidden;
            }
        
        }

        private void Button_restart(object sender, RoutedEventArgs e)
        {
            Window2 win2 = new Window2();
            win2.Show();
            this.Close();

        }

        private void Button_send_to_server(object sender, RoutedEventArgs e)
        {
            var BL = new AstronomyBL.firebase.UploadImage();
            BL.SendImageToServer(stream, longitude.Text, latitude.Text);
        }
    }
}

