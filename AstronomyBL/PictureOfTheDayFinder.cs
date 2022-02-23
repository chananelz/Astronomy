﻿using AstronomyDAL;
using AstronomyDP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using RestSharp;

namespace AstronomyBL
{
    public class PictureOfTheDayFinder
    {
        private Picture_of_the_day_reader PictureOfTheDayCollection;

        public PictureOfTheDayFinder()
        {
            PictureOfTheDayCollection = new Picture_of_the_day_reader();
        }

        public List<Picture_of_the_day> Get_picture_of_the_day_By_day(string selectedDay)
        {
            var Result = (from myPicture in PictureOfTheDayCollection.Pictures
                          where myPicture.Date
                          == selectedDay
                          select myPicture
                          ).ToList<Picture_of_the_day>();
            return Result;

        }

        public String Get_today_picture_of_the_day()  // TODO - conect this to what we get from the nasa api
        {

            string apiKey = "mDhUZ35bcvoItcZj4s0qOHhaenI73sT2rANWSysZ";

            var client = new RestClient("https://api.nasa.gov/planetary/apod");
            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            request.AddParameter("api_key", apiKey);

            IRestResponse response = client.Execute(request);
            RootPictureOfTheDAY myDeserializedClass = JsonConvert.DeserializeObject<RootPictureOfTheDAY>(response.Content);

            var Result = myDeserializedClass.url;
            return Result;

        }


    }
}
