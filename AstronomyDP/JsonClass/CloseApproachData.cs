using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstronomyDP.JsonClass
{
    public class CloseApproachData
    {
        public string close_approach_date { get; set; }
        public string close_approach_date_full { get; set; }
        public object epoch_date_close_approach { get; set; }
        public RelativeVelocity relative_velocity { get; set; }
        public MissDistance miss_distance { get; set; }
        public string orbiting_body { get; set; }
    }
}
