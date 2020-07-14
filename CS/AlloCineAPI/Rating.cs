using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
    public class Rating
    {
        [JsonPropertyName("note")]
        public float Note { get; set; }

        [JsonPropertyName("$")]
        public string Value { get; set; }
    }
}
