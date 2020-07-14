using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract(Name = "movie")]
    public class Movie
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("movieType")]
        public MovieType MovieType { get; set; }

        [JsonPropertyName("originalTitle")]
        public string OriginalTitle { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("keywords")]
        public string Keywords { get; set; }

        [JsonPropertyName("productionYear")]
        public int ProductionYear { get; set; }

        [JsonPropertyName("nationality")]
        public List<Nationality> NationalityList { get; set; }

        [JsonPropertyName("genre")]
        public List<Genre> GenreList { get; set; }

        [JsonPropertyName("release")]
        public Release Release { get; set; }

        [JsonPropertyName("runtime")]
        public string Runtime { get; set; }

        [JsonPropertyName("color")]
        public Color Color { get; set; }

        [JsonPropertyName("formatList")]
        public Formatlist Formatlist { get; set; }

        [JsonPropertyName("language")]
        public List<Language> LanguageList { get; set; }

        [JsonPropertyName("budget")]
        public string Budget { get; set; }

        [JsonPropertyName("synopsis")]
        public string Synopsis { get; set; }

        [JsonPropertyName("synopsisShort")]
        public string SynopsisShort { get; set; }

        [JsonPropertyName("castingShort")]
        public CastingShort CastingShort { get; set; }

        [JsonPropertyName("castMember")]
        public List<CastMember> CastMemberList { get; set; }

        [JsonPropertyName("poster")]
        public Poster Poster { get; set; }

        [JsonPropertyName("trailer")]
        public Trailer Trailer { get; set; }

        [JsonPropertyName("trailerEmbed")]
        public string TrailerEmbed { get; set; }

        [JsonPropertyName("defaultMedia")]
        public DefaultMedia DefaultMedia { get; set; }

        [JsonPropertyName("hasShowtime")]
        public int HasShowtime { get; set; }

		[JsonPropertyName("hasVOD")]
        public int HasVod { get; set; }
		
		[JsonPropertyName("hasDVD")]
        public int HasDvd { get; set; }

		[JsonPropertyName("dvdReleaseDate")]
		public DateTime? DvdReleaseDate { get; set; }

        [JsonPropertyName("link")]
        public List<Link> LinkList { get; set; }

        [JsonPropertyName("media")]
        public List<Media> MediaList { get; set; }

        [JsonPropertyName("statistics")]
        public Statistics Statistics { get; set; }

        [JsonPropertyName("news")]
        public List<News> NewsList { get; set; }

        [JsonPropertyName("feature")]
        public List<Feature> FeatureList { get; set; }

        [JsonPropertyName("trivia")]
        public List<Trivia> TriviaList { get; set; }

        [JsonPropertyName("tag")]
        public List<Tag> TagList { get; set; }

        [JsonPropertyName("festivalAward")]
        public List<FestivalAward> FestivalAwardList { get; set; }

        [JsonPropertyName("boxOffice")]
        public List<BoxOffice> BoxOfficeList { get; set; }

        [JsonPropertyName("helpfulPositiveReview")]
        public List<HelpfulPositiveReview> HelpfulPositiveReviewList { get; set; }

        [JsonPropertyName("helpfulNegativeReview")]
        public List<HelpfulNegativeReview> HelpfulNegativeReviewList { get; set; }

        public Error Error { get; set; }

    }
}
