using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract(Name = "season")]
    public class Season
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("parentSeries")]
        public ParentSeries ParentSeries { get; set; }

        [JsonPropertyName("seasonNumber")]
        public int SeasonNumber { get; set; }

        [JsonPropertyName("episodeCount")]
        public int EpisodeCount { get; set; }

        [JsonPropertyName("productionStatus")]
        public ProductionStatus ProductionStatus { get; set; }

        [JsonPropertyName("yearStart")]
        public int YearStart { get; set; }

        [JsonPropertyName("yearEnd")]
        public int YearEnd { get; set; }

        [JsonPropertyName("trailerEmbed")]
        public string TrailerEmbed { get; set; }

        [JsonPropertyName("castMember")]
        public List<CastMember> CastMemberList { get; set; }

        [JsonPropertyName("episode")]
        public List<Episode> EpisodeList { get; set; }

        [JsonPropertyName("link")]
        public List<Link> LinkList { get; set; }

        [JsonPropertyName("media")]
        public List<Media> MediaList { get; set; }

        [JsonPropertyName("statistics")]
        public Statistics Statistics { get; set; }

        public Error Error { get; set; }
    }
}
