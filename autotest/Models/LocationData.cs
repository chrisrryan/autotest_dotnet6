using System.Text.Json.Serialization;

namespace autotest.Models
{
    public class LocationData
    {
        [JsonPropertyName("post code")]
        public string PostCode { get; set; }
        public string Country { get; set; }
        [JsonPropertyName("country abbreviation")]
        public string CountryAbbreviation { get; set; }
        public List<Place> Places { get; set; }
    }
}