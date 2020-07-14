using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract(Name = "castingShort")]
    public class CastingShort
    {
        [JsonPropertyName("directors")]
        public string Directors { get; set; }

        [JsonPropertyName("actors")]
        public string Actors { get; set; }

        [JsonPropertyName("creators")]
        public string Creators { get; set; }

    }
}