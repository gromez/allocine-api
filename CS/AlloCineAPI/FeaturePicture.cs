using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
    public class FeaturePicture
    {
        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}