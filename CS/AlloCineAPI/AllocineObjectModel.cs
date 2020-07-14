using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
    internal class AllocineObjectModel
	{
		[JsonPropertyName("error")]
		public Error Error { get; set; }

        [JsonPropertyName("movie")]
        public Movie Movie { get; set; } = new Movie();

        [JsonPropertyName("feed")]
        public Feed Feed { get; set; } = new Feed();

        [JsonPropertyName("person")]
        public Person Person { get; set; } = new Person();

        [JsonPropertyName("media")]
        public Media Media { get; set; } = new Media();

        [JsonPropertyName("tvseries")]
        public TvSeries TvSeries { get; set; } = new TvSeries();

        [JsonPropertyName("season")]
        public Season Season { get; set; } = new Season();

        [JsonPropertyName("episode")]
        public Episode Episode { get; set; } = new Episode();
    }
}
