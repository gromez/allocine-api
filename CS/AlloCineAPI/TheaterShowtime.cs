using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
    public class TheaterShowtime
    {
        [JsonPropertyName("place")]
        public Place Place { get; set; }

        [JsonPropertyName("movieShowtimes")]
        public List<MovieShowtime> MovieShowtimeList { get; set; }
    }
}

