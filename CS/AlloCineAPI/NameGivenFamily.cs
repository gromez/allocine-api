using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
    public class NameGivenFamily
    {
        [JsonPropertyName("given")]
        public string Given { get; set; }

        [JsonPropertyName("family")]
        public string Family { get; set; }
    }
}
