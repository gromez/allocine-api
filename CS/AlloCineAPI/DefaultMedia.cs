using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
    public class DefaultMedia
    {
        [JsonPropertyName("media")]
        public Media Media { get; set; }
    }
}

