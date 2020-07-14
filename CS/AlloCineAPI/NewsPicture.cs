using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
    public class NewsPicture
    {
        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}