using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract(Name = "error")]
    public class Error
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("$")]
        public string Value { get; set; }
    }
}

