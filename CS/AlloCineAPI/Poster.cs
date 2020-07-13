using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract(Name = "poster")]
    public class Poster
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }
    }
}

