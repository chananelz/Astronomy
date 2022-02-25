using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstronomyDP.JsonClass
{
    public class Datum
    {
        public string center { get; set; }
        public string title { get; set; }
        public string nasa_id { get; set; }
        public string media_type { get; set; }
        public List<string> keywords { get; set; }
        public DateTime date_created { get; set; }
        public string description_508 { get; set; }
        public string secondary_creator { get; set; }
        public string description { get; set; }
        public List<string> album { get; set; }
        public string photographer { get; set; }
        public string location { get; set; }
    }
}
