using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstronomyDP.JsonClass
{
    public class Collection
    {
        public string version { get; set; }
        public string href { get; set; }
        public List<Item> items { get; set; }
        public Metadata metadata { get; set; }
        public List<Link> links { get; set; }
    }
}
