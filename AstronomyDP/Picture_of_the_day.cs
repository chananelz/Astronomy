using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstronomyDP
{
    public class Picture_of_the_day
    {
        public string Url { get; set; } // The url is the ID of this object
        public string Date { get; set; } // I use string insted of Datetime because it more esye to the DB
        public string Classification { get; set; }
        
    }
}
