using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstronomyDP.JsonClass
{
    public class Item
    {
        public string href { get; set; }
        public List<Datum> data { get; set; }
        public List<Link> links { get; set; }
    }

}
