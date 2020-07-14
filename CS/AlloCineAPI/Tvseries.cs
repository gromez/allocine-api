using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract(Name = "tvseries")]
    public class TvSeries
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("seriesType")]
        public SeriesType SeriesType { get; set; }

        [JsonPropertyName("originalTitle")]
        public string OriginalTitle { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("keywords")]
        public string Keywords { get; set; }

        [JsonPropertyName("originalBroadcast")]
        public OriginalBroadcast OriginalBroadcast { get; set; }

        [JsonPropertyName("originalChannel")]
        public OriginalChannel OriginalChannel { get; set; }

        [JsonPropertyName("formatTime")]
        public int FormatTime { get; set; }

        [JsonPropertyName("productionStatus")]
        public ProductionStatus ProductionStatus { get; set; }

        [JsonPropertyName("season")]
        public List<Season> SeasonList { get; set; }

        [JsonPropertyName("seasonCount")]
        public int SeasonCount { get; set; }

        [JsonPropertyName("episodeCount")]
        public int EpisodeCount { get; set; }

        [JsonPropertyName("yearStart")]
        public int YearStart { get; set; }

        [JsonPropertyName("yearEnd")]
        public int YearEnd { get; set; }

        [JsonPropertyName("hasBluRay")]
        public int HasBluRay { get; set; }

        [JsonPropertyName("hasDVD")]
        public int HasDVD { get; set; }

        [JsonPropertyName("nationality")]
        public List<Nationality> NationalityList { get; set; }

        [JsonPropertyName("genre")]
        public List<Genre> GenreList { get; set; }

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

        [JsonPropertyName("topBanner")]
        public TopBanner TopBanner { get; set; }

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

        [JsonPropertyName("helpfulPositiveReview")]
        public List<HelpfulPositiveReview> HelpfulPositiveReviewList { get; set; }

        [JsonPropertyName("helpfulNegativeReview")]
        public List<HelpfulNegativeReview> HelpfulNegativeReviewList { get; set; }

        public Error Error { get; set; }
    }
}
