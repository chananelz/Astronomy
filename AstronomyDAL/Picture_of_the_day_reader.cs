using AstronomyDP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Elya Kofler 212853139
// Chananel Zaguri 206275711

namespace AstronomyDAL
{
    public class Picture_of_the_day_reader
    {
        public List<PictureOfTheDay> Pictures { get; set; }

        public Picture_of_the_day_reader()
        {
            using (APDBEntities context = new APDBEntities())
            {
                Pictures = (from U in context.PictureOfTheDay
                                select U).ToList();
            }

        }

        public void AddNewPictureOfTheDay(PictureOfTheDay picture)
        {
            using (APDBEntities context = new APDBEntities())
            {
                context.PictureOfTheDay.Add(picture);
                context.SaveChanges();
            }
        }
    }
}
