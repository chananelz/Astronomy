using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AstronomyDP.JsonClass
{
    public class NearAstridCollection
    {
        [JsonProperty("near_earth_objects")]
        public Dictionary<string, List<GetNearAsteroidNasaDto>> NearAstroids { get; set; }
    }
}
