using AstronomyDAL;
using AstronomyDP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
