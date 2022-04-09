using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstronomyDP
{
    public class Asteroid
    {
        public string Name { get; set; } // save the name acording to nasa
        public string ID { get; set; }
        public string AbsoluteMagnitude { get; set; } // הארה יחסית של הכוכב
        public string diameterMin { get; set; } // קוטר
        public string diameterMax { get; set; } // קוטר
        public string EpochDate { get; set; } // נכון לזמן..
        public string Velocity { get; set; }
        public string missDistance { get; set; }   // מרחק ממסלול כדור הארץ
        public string OrbitingBody { get; set; }   // איז כוח גרביטציה של כוכב לכת משפיע עליו
        public string IsPotentiallyHazardousAsteroid { get; set; } // רק בפוטנציאל הרסני
        public string IsSentryObject { get; set; }  // ממש מסוכן
        public string ObjectUri { get; set; }  // save uri to nasa like https://ssd.jpl.nasa.gov/tools/sbdb_lookup.html#/?sstr=2363505&view=VOP
        public string ObjectImage { get; set; }  // ilostriation of the astroi

        //public Asteroid(string Name, string ID, string AbsoluteMagnitude, string diameterMin, string diameterMax, string EpochDate, string Velocity, string missDistance, string OrbitingBody, string IsPotentiallyHazardousAsteroid, string IsSentryObject, string ObjectUri, string ObjectImage)
        //{
        //    this.Name = Name;   
        //    this.ID = ID;   
        //    this.AbsoluteMagnitude = AbsoluteMagnitude;
        //    this.diameterMin = diameterMin;
        //    this.diameterMax = diameterMax;
        //    this.EpochDate = EpochDate;
        //    this.Velocity = Velocity;
        //    this.missDistance = missDistance;
        //    this.OrbitingBody = OrbitingBody;
        //    this.IsPotentiallyHazardousAsteroid = IsPotentiallyHazardousAsteroid;
        //    this.IsSentryObject = IsSentryObject;
        //    this.ObjectUri = ObjectUri;
        //    this.ObjectImage = ObjectImage; 

        //}
    }
}
