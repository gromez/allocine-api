using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
    public class DisplayMode
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }
    }
}
