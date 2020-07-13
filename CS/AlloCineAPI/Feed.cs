using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Allocine.ExtensionMethods;

namespace AlloCine
{
    [DataContract(Name = "feed")]
    public class Feed
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("results")]
        public List<Results> ResultsList { get; set; }

        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("movie")]
        public List<Movie> MovieList { get; set; }

        [JsonPropertyName("theater")]
        public List<Theater> TheaterList { get; set; }

        [JsonPropertyName("location")]
        public List<Location> LocationList { get; set; }

        [JsonPropertyName("person")]
        public List<PersonLight> PersonList { get; set; }

        [JsonPropertyName("tvseries")]
        public List<TvSeries> TvSeriesList { get; set; }

        [JsonPropertyName("news")]
        public List<News> NewsList { get; set; }

        [JsonPropertyName("media")]
        public List<Media> MediaList { get; set; }

        [JsonPropertyName("updated")]
        private string UpdatedString
        {
            get { throw new NotImplementedException(); }
            set { Updated = value.toDate(); }
        }
        public DateTime Updated { get; set; }

        [JsonPropertyName("review")]
        public List<Review> ReviewList { get; set; }

        [JsonPropertyName("theaterShowtimes")]
        public List<TheaterShowtime> TheaterShowtimeList { get; set; }

        public Error Error { get; set; }
    }
}