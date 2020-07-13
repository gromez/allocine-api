using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract(Name = "locationType")]
    public class LocationType
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("$")]
        public string Value { get; set; }
    }
}

