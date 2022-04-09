using AstronomyDP;
using AstronomyDP.JsonClass;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstronomyBL
{
    public class AsteroidFinder
    {
        public AsteroidFinder()
        {
            GetAsteroids();
        }
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
            , @"\Assets\Asteroids\12.jpg", @"\Assets\Asteroids\13.jpg", @"\Assets\Asteroids\14.jpg", @"\Assets\Asteroids\15.jpg", @"\Assets\Asteroids\16.jpg", @"\Assets\Asteroids\17.jpg"
            , @"\Assets\Asteroids\18.jpg", @"\Assets\Asteroids\19.jpg", @"\Assets\Asteroids\20.jpg", @"\Assets\Asteroids\21.jpg", @"\Assets\Asteroids\22.jpg", @"\Assets\Asteroids\23.jpg"
            , @"\Assets\Asteroids\24.jpg", @"\Assets\Asteroids\25.jpg", @"\Assets\Asteroids\26.jpg", @"\Assets\Asteroids\27.jpg", @"\Assets\Asteroids\28.jpg", @"\Assets\Asteroids\29.jpg"
            , @"\Assets\Asteroids\30.jpg", @"\Assets\Asteroids\31.jpg", @"\Assets\Asteroids\32.jpg", @"\Assets\Asteroids\33.jpg", @"\Assets\Asteroids\34.jpg", @"\Assets\Asteroids\35.jpg"
            , @"\Assets\Asteroids\36.jpg", @"\Assets\Asteroids\37.jpg", @"\Assets\Asteroids\38.jpg", @"\Assets\Asteroids\39.jpg", @"\Assets\Asteroids\40.jpg", @"\Assets\Asteroids\41.jpg"
            , @"\Assets\Asteroids\42.jpg", @"\Assets\Asteroids\43.jpg", @"\Assets\Asteroids\44.jpg", @"\Assets\Asteroids\45.jpg", @"\Assets\Asteroids\46.jpg", @"\Assets\Asteroids\47.jpg"
            , @"\Assets\Asteroids\48.jpg", @"\Assets\Asteroids\49.jpg", @"\Assets\Asteroids\50.jpg"};

            foreach (var item in result)
            {
                int mIndex = rnd.Next(asteroids_image.Length);
                AllAsteroids.Add (new Asteroid {
                    Name = item.Name, ObjectImage = asteroids_image[mIndex], ID = item.NeoReferenceId, AbsoluteMagnitude = item.AbsoluteMagnitudeH.ToString(), diameterMin = "Min:  " + item.EstimatedDiameterMin.ToString(),
                    diameterMax = "Max:  " + item.EstimatedDiameterMax.ToString(), EpochDate = item.CloseApproachDate.ToShortDateString(), IsPotentiallyHazardousAsteroid = item.IsPotentiallyHazardousAsteroid.ToString(),
                    IsSentryObject = item.IsSentryObject.ToString(),
                    missDistance = item.MissDistance, ObjectUri = "https://ssd.jpl.nasa.gov/tools/sbdb_lookup.html#/?sstr=" + item.NeoReferenceId + "&view=VOP", OrbitingBody = item.orbiting_body, Velocity = item.Velocity });
            }

            writeAsteroids_to_DB(AllAsteroids);
            return AllAsteroids;
        }

        public List<Asteroid> GetAsteroids_by_risk(string selected_risk)
        {
            string risk = "True";

            if (selected_risk == "No")
            {
                risk = "False";
            }

            List<Asteroid> allAsteroids = GetAsteroids_from_DB();
            

            var Result = (from asteroid in allAsteroids
                          where asteroid.IsPotentiallyHazardousAsteroid == risk
                          select asteroid
                          ).ToList<Asteroid>();
            return Result;
        }

        public List<Asteroid> GetAsteroids_by_Diameter(float min_Diameter)
        {
            List<Asteroid> allAsteroids = GetAsteroids_from_DB();

            var Result = (from asteroid in allAsteroids
                          where (float)Convert.ToDouble(asteroid.diameterMax.Split(' ')[2]) >= min_Diameter
                          select asteroid
              ).ToList<Asteroid>();
            return Result;
        }

        public List<Asteroid> GetAsteroids_by_day(string Date)
        {
            List<Asteroid> allAsteroids = GetAsteroids_from_DB();

            var Result = (from asteroid in allAsteroids
                          where asteroid.EpochDate == Date
                          select asteroid
                          ).ToList<Asteroid>();
            return Result;
        }


        public List<Asteroid> GetAsteroids_from_DB()
        {
            List<Asteroid> result = new List<Asteroid> ();
            AstronomyDAL.AsteroidReader AsteroidCollection = new AstronomyDAL.AsteroidReader();

            foreach (var myAsteroid in AsteroidCollection.AllAsteroidDetails)
            {
                result.Add(new Asteroid
                {
                    Name = myAsteroid.Name,
                    ObjectImage = myAsteroid.ObjectImage,
                    ID = myAsteroid.ID,
                    AbsoluteMagnitude = myAsteroid.AbsoluteMagnitude,
                    diameterMin = myAsteroid.diameterMin,
                    diameterMax = myAsteroid.diameterMax,
                    EpochDate = myAsteroid.EpochDate,
                    IsPotentiallyHazardousAsteroid = myAsteroid.IsPotentiallyHazardousAsteroid,
                    IsSentryObject = myAsteroid.IsSentryObject,
                    missDistance = myAsteroid.missDistance,
                    ObjectUri = myAsteroid.ObjectUri,
                    OrbitingBody = myAsteroid.OrbitingBody,
                    Velocity = myAsteroid.Velocity
                });
            }
            return result;
        }

        public void writeAsteroids_to_DB(List<Asteroid> toDayAstroides)
        {
            AstronomyDAL.AsteroidReader AsteroidInsert = new AstronomyDAL.AsteroidReader();
            foreach (var myAsteroid in toDayAstroides)
            {
                AsteroidInsert.AddNewAsteroid(new AstronomyDAL.AsteroidnNearEarth
                {
                    Name = myAsteroid.Name,
                    ObjectImage = myAsteroid.ObjectImage,
                    ID = myAsteroid.ID,
                    AbsoluteMagnitude = myAsteroid.AbsoluteMagnitude,
                    diameterMin = myAsteroid.diameterMin,
                    diameterMax = myAsteroid.diameterMax,
                    EpochDate = myAsteroid.EpochDate,
                    IsPotentiallyHazardousAsteroid = myAsteroid.IsPotentiallyHazardousAsteroid,
                    IsSentryObject = myAsteroid.IsSentryObject,
                    missDistance = myAsteroid.missDistance,
                    ObjectUri = myAsteroid.ObjectUri,
                    OrbitingBody = myAsteroid.OrbitingBody,
                    Velocity = myAsteroid.Velocity
                });
            }
        }

    }
}
