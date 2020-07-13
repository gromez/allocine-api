using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract(Name = "movieType")]
    public class MovieType
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("$")]
        public string Value { get; set; }
    }
}