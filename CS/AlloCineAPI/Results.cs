using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
    public class Results
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("INVALID_MEMBER_NAME")]
        public int Value { get; set; }
    }
}

