using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Allocine.ExtensionMethods;

namespace AlloCine
{
    [DataContract(Name = "feed")]
    public class Feed
    {
        [DataMember(Name = "page")]
        public int Page { get; set; }

        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "results")]
        public List<Results> ResultsList { get; set; }

        [DataMember(Name = "totalResults")]
        public int TotalResults { get; set; }

        [DataMember(Name = "movie")]
        public List<Movie> MovieList { get; set; }

        [DataMember(Name = "theater")]
        public List<Theater> TheaterList { get; set; }

        [DataMember(Name = "location")]
        public List<Location> LocationList { get; set; }

        [DataMember(Name = "person")]
        public List<PersonLight> PersonList { get; set; }

        [DataMember(Name = "tvseries")]
        public List<TvSeries> TvSeriesList { get; set; }

        [DataMember(Name = "news")]
        public List<News> NewsList { get; set; }

        [DataMember(Name = "media")]
        public List<Media> MediaList { get; set; }

        [DataMember(Name = "updated")]
        private string UpdatedString
        {
            get { throw new NotImplementedException(); }
            set { Updated = value.toDate(); }
        }
        public DateTime Updated { get; set; }

        [DataMember(Name = "review")]
        public List<Review> ReviewList { get; set; }

        [DataMember(Name = "theaterShowtimes")]
        public List<TheaterShowtime> TheaterShowtimeList { get; set; }

        public Error Error { get; set; }
    }
}