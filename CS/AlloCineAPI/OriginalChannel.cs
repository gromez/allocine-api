using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract(Name = "originalChannel")]
    public class OriginalChannel
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("$")]
        public string Value { get; set; }

        [JsonPropertyName("country")]
        public Country Country { get; set; }
    }
}
