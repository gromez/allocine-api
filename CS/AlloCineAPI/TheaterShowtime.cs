using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    public class TheaterShowtime
    {
        [DataMember(Name = "place")]
        public Place Place { get; set; }

        [DataMember(Name = "movieShowtimes")]
        public List<MovieShowtime> MovieShowtimeList { get; set; }
    }
}

