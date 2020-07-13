using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
    public class OnShow
    {
        [JsonPropertyName("movie")]
        public Movie Movie { get; set; }
    }
}