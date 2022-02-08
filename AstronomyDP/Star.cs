using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Elya Kofler 212853139
// Chananel Zaguri 206275711

namespace AstronomyDP
{
    public class Star
    {
        public string Name { get; set; } // save the name acording to nasa
        public string ObjectUri { get; set; }  // save uri to nasa like https://ssd.jpl.nasa.gov/tools/sbdb_lookup.html#/?sstr=2363505&view=VOP
        public string Id { get; set; }
        public string AbsoluteMagnitude { get; set; } // הארה יחסית של הכוכב
        public string diameterAvrege { get; set; } // קוטר
        public string IsPotentiallyHazardousAsteroid { get; set; } // רק בפוטנציאל הרסני
        public string Velocity { get; set; }
        public string missDistance { get; set; }   // מרחק ממסלול כדור הארץ
        public string OrbitingBody { get; set; }   // איז כוח גרביטציה של כוכב לכת משפיע עליו
        public string IsSentryObject { get; set; }  // ממש מסוכן




        public override string ToString()
        {
            return "Name: " + Name + "   ObjectUri: " + ObjectUri;
        }

    }


}
