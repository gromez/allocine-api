using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract(Name = "topBanner")]
    public class TopBanner
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}

