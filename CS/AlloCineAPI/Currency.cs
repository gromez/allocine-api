using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract(Name = "currency")]
    public class Currency
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }
    }
}

