using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
    public class ReviewUrl
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
