using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstronomyDAL
{
    public class AsteroidReader
    {
        public List<AsteroidnNearEarth> AllAsteroidDetails { get; set; }

        public AsteroidReader()
        {
            using (APDBEntities context = new APDBEntities())
            {
                AllAsteroidDetails = (from U in context.AsteroidnNearEarth
                                      select U).ToList();
            }
        }

        public void AddNewAsteroid(AsteroidnNearEarth myAsteroid)
        {
            if ((from Asteroid in AllAsteroidDetails       
                 where (Asteroid.ID == myAsteroid.ID &&  Asteroid.EpochDate == myAsteroid.EpochDate)
                 select Asteroid).Any() == true)
            {
                return ;
            }

                AllAsteroidDetails.Add(myAsteroid);
            using (APDBEntities context = new APDBEntities())
            {
                context.AsteroidnNearEarth.Add(myAsteroid);
                context.SaveChanges();
            }
        }

    }
}

