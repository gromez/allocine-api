using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract(Name = "participation")]
    public class Participation
    {
        [JsonPropertyName("movie")]
        public Movie Movie { get; set; }

        [JsonPropertyName("activity")]
        public Activity Activity { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }
    }
}

