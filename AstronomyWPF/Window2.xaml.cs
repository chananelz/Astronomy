using Microsoft.Win32;
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

namespace AstronomyWPF
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
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

        private async void Button_Click(object sender, RoutedEventArgs e)
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
                string output = Convert.ToBase64String(imgData);
                var data = new Image_Modal
                {
                    Img = output
                };
                SetResponse response = await client.SetTaskAsync("Image/", data);
                Image_Modal result = response.ResultAs<Image_Modal>();

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


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
