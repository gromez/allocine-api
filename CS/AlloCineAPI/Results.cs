using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
    public class Results
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("$")]
        public int Value { get; set; }
    }
}

