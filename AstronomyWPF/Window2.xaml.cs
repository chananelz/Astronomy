﻿using Microsoft.Win32;
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
using System.Drawing;
using System.IO;
using AstronomyDP;
using FireSharp.Response;
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp;
using Newtonsoft.Json;
using Microsoft.Maps.MapControl.WPF;
using Firebase;
using Firebase.Storage;
using Firebase.Auth;

namespace AstronomyWPF
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        string mystring = "qweqweqweq";
        IFirebaseConfig fc = new FireSharp.Config.FirebaseConfig
        {
            AuthSecret = "gPqWPJP1H6zF7bZo1jQf5ax91slhGLmdPSY8fuvt",
            BasePath = "https://fir-astronomy-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
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

            // Adds the pushpin to the map.
            MyMap.Children.Clear();
            MyMap.Children.Add(pin);
            
        }

        private  void Button_Click(object sender, RoutedEventArgs e)
        {


            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image Files(*.jpg) | *.jpg";

            if (ofd.ShowDialog() == true)
            {
                
                //System.Windows.Media.ImageSource img = new BitmapSource(ofd.FileName);
                //pictureBox.Source = img.GetThumbnailImage(240, 161, null, new IntPtr());
                System.Drawing.Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                Bitmap myBitmap = new Bitmap(ofd.FileName);
                pictureBox.Source = BitmapToImageSource((Bitmap)myBitmap.GetThumbnailImage(240, 161, null, new IntPtr()));

                byte[] imgData = System.IO.File.ReadAllBytes(ofd.FileName);
                mystring = Convert.ToBase64String(imgData);
                //var data = new Image_Modal
                //{
                //    Img = output
                //};
                //SetResponse response =  client.Set("Image/" + "dsfs", data);
                //Image_Modal result = response.ResultAs<Image_Modal>();

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var data = new Image_Modal
                {
                    Img = mystring,
                    Longitude = "111",
                    Latitude = "0000"
            };

            client = new FirebaseClient(fc);
            var seret = client.Set("Image/" + "Image3", data);
            
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Get any Stream - it can be FileStream, MemoryStream or any other type of Stream
            var stream = File.Open(@"C:\Users\user1\Desktop\1\22.jpg", FileMode.Open);

            //authentication
            var auth = new FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig("AIzaSyCYU2lIa1AepwS8PW2vBT3qaxP5bykXlOU"));
            var a = await auth.SignInWithEmailAndPasswordAsync("firebasestorage44@gmail.com", "9ijn8uhb7ygv");


            // Constructr FirebaseStorage, path to where you want to upload the file and Put it there
            var task = new FirebaseStorage(
                "fir-astronomy.appspot.com",
            
                 new FirebaseStorageOptions
                 {
                     AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                     ThrowOnCancel = true,
                 })
                .Child("data")
                .Child("random")
                .Child("22.jpg")
                .PutAsync(stream);

            // Track progress of the upload
            task.Progress.ProgressChanged += (s, ee) => Console.WriteLine($"Progress: {ee.Percentage} %");

            // await the task to wait until upload completes and get the download url
            var downloadUrl = await task;

        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Newtonsoft.Json;
//using RestSharp;

//namespace ImaggaAPIlev
//{
//    public class Nasa
//    {
//        public void getApod()
//        {
//            string apiKey = "mDhUZ35bcvoItcZj4s0qOHhaenI73sT2rANWSysZ";

//            var client = new RestClient("https://api.nasa.gov/planetary/apod");
//            client.Timeout = -1;

//            var request = new RestRequest(Method.GET);
//            request.AddParameter("api_key", apiKey);

//            IRestResponse response = client.Execute(request);
//            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response.Content);
//            Console.WriteLine(myDeserializedClass.url);
//            Console.ReadLine();
//        }
//    }

//}
