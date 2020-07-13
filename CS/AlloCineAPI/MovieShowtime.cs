using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
    public class MovieShowtime
    {
        [JsonPropertyName("preview")]
        public string Preview { get; set; }

        [JsonPropertyName("releaseWeek")]
        public string ReleaseWeek { get; set; }

        [JsonPropertyName("onShow")]
        public OnShow OnShow { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        [JsonPropertyName("screenFormat")]
        public ScreenFormat ScreenFormat { get; set; }

        [JsonPropertyName("display")]
        public string Display { get; set; }

        [JsonPropertyName("scr")]
        public List<Scr> ScrList { get; set; }
    }
}

