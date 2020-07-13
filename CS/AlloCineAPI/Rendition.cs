using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
    public class Rendition
    {
        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("format")]
        public Format Format { get; set; }

    }
}
