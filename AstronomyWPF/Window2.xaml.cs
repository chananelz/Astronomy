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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
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
