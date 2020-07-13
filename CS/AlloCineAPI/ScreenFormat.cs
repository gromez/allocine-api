using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
    public class ScreenFormat
    {
        [JsonPropertyName("code")]
        public int Type { get; set; }

        [JsonPropertyName("INVALID_MEMBER_NAME")]
        public string Value { get; set; }
    }
}
