using AstronomyDP;
using AstronomyDP.JsonClass;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstronomyBL
{
    public class AsteroidFinder
    {
        public List<Asteroid> GetAsteroids()
        {
            List <Asteroid> AllAsteroids = new List <Asteroid> ();
            string apiKey = "mDhUZ35bcvoItcZj4s0qOHhaenI73sT2rANWSysZ";
            DateTime time1 = DateTime.Now;

            string todayDay = $"{time1:s}".Split('T')[0];



            var client = new RestClient("http://www.neowsapp.com/rest/v1/feed?start_date=" + todayDay + "&end_date=" + todayDay);
            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            request.AddParameter("api_key", apiKey);

            IRestResponse response = client.Execute(request);

            var dict = JsonConvert.DeserializeObject<NearAstridCollection>(response.Content);

            var result = new List<GetNearAsteroidNasaDto>();
            foreach (var item in dict.NearAstroids)
            {
                var temp = item.Value;
                temp.ForEach(a => a.CloseApproachDate = DateTime.Parse(item.Key));
                result.AddRange(temp);
            }

            Random rnd = new Random();

            string[] asteroids_image = { @"\Assets\Asteroids\1.jpg", @"\Assets\Asteroids\2.jpg", @"\Assets\Asteroids\3.jpg", @"\Assets\Asteroids\4.jpg", @"\Assets\Asteroids\5.jpg"
            , @"\Assets\Asteroids\6.jpg", @"\Assets\Asteroids\7.jpg", @"\Assets\Asteroids\8.jpg", @"\Assets\Asteroids\9.jpg", @"\Assets\Asteroids\10.jpg", @"\Assets\Asteroids\11.jpg"
            , @"\Assets\Asteroids\12.jpg", @"\Assets\Asteroids\13.jpg", @"\Assets\Asteroids\14.jpg", @"\Assets\Asteroids\15.jpg"};

            foreach (var item in result)
            {
                int mIndex = rnd.Next(asteroids_image.Length);
                AllAsteroids.Add (new Asteroid {
                    Name = item.Name, ObjectImage = asteroids_image[mIndex], ID = item.NeoReferenceId, AbsoluteMagnitude = item.AbsoluteMagnitudeH.ToString(), diameterMin = item.EstimatedDiameterMin.ToString(),
                    diameterMax = item.EstimatedDiameterMax.ToString(), EpochDate = item.CloseApproachDate.ToShortDateString(), IsPotentiallyHazardousAsteroid = item.IsPotentiallyHazardousAsteroid.ToString(),
                    IsSentryObject = item.IsSentryObject.ToString(),
                    missDistance = item.MissDistance, ObjectUri = "https://ssd.jpl.nasa.gov/tools/sbdb_lookup.html#/?sstr=" + item.NeoReferenceId + "&view=VOP", OrbitingBody = item.orbiting_body, Velocity = item.Velocity });
            }


            return AllAsteroids;

        }
    }
}
