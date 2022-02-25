using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstronomyDP.JsonClass;
using Newtonsoft.Json;
using RestSharp;

namespace AstronomyBL
{
    public class InformationAboutPlanetFinder
    {
        public List<String> Get_information_about_planet_finder(String PlanetString)
        {

            //string apiKey = "mDhUZ35bcvoItcZj4s0qOHhaenI73sT2rANWSysZ";

            var client = new RestClient("https://images-api.nasa.gov/search?q="+ PlanetString + "&media_type=image");
            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            //request.AddParameter("api_key", apiKey);


            var x = request;

            IRestResponse response = client.Execute(request);

            var y = response.Content;
            RootPlanet myDeserializedClass = JsonConvert.DeserializeObject<RootPlanet>(response.Content);

            List<String> Result = new List<String>();   

            for (int i = 0; i < 9; i++)
            {
                try
                {
                    Result.Add(myDeserializedClass.collection.items[i].links[0].href);
                }
                catch (Exception)
                {

                    Result.Add("");
                }
            }

            
            return Result;

        }
    }
}
