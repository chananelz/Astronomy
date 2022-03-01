using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstronomyDP.JsonClass
{
    public class GetNearAsteroidNasaDto
    {
        [JsonProperty("neo_reference_id")]
        public string NeoReferenceId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nasa_jpl_url")]
        public string NasaJplUrl { get; set; }

        [JsonProperty("absolute_magnitude_h")]
        public double AbsoluteMagnitudeH { get; set; }

        [JsonProperty("estimated_diameter")]
        public EstimatedDiameter EstimatedDiameterDto { get; set; }

        [JsonProperty("close_approach_data")]
        public List<CloseApproachData> CloseApproachData { get; set; }

        [JsonProperty("is_potentially_hazardous_asteroid")]
        public bool IsPotentiallyHazardousAsteroid { get; set; }


        [JsonProperty("is_sentry_object")]
        public bool IsSentryObject { get; set; }

        public DateTime CloseApproachDate { get; set; }

        public float KilometersPerSecond { get; set; }

        public double EstimatedDiameterMax { get => EstimatedDiameterDto.kilometers.estimated_diameter_max; }
        public string orbiting_body { get => CloseApproachData[0].orbiting_body; }

        public string Velocity { get => CloseApproachData[0].relative_velocity.kilometers_per_hour; }

        public string MissDistance { get => CloseApproachData[0].miss_distance.kilometers; }


        public double EstimatedDiameterMin { get => EstimatedDiameterDto.kilometers.estimated_diameter_min; }
    }
}
