using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract(Name = "place")]
    public class Place
    {
        [JsonPropertyName("theater")]
        public Theater Theater { get; set; }
    }
}
