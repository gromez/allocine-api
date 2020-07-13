using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
    public class ScreenFormat
    {
        [JsonPropertyName("code")]
        public int Type { get; set; }

        [JsonPropertyName("$")]
        public string Value { get; set; }
    }
}
