using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Allocine.ExtensionMethods;

namespace AlloCine
{
    [DataContract(Name = "episode")]
    public class Episode
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("parentSeries")]
        public ParentSeries ParentSeries { get; set; }

        [JsonPropertyName("parentSeason")]
        public ParentSeason ParentSeason { get; set; }

        [JsonPropertyName("originalTitle")]
        public string OriginalTitle { get; set; }

        [JsonPropertyName("originalBroadcastDate")]
        private string OriginalBroadcastDateString
        {
            get { throw new NotImplementedException(); }
            set { OriginalBroadcastDate = value.toDate(); }
        }
        public DateTime OriginalBroadcastDate { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("episodeNumberSeries")]
        public string EpisodeNumberSeries { get; set; }

        [JsonPropertyName("episodeNumberSeason")]
        public string EpisodeNumberSeason { get; set; }

        [JsonPropertyName("synopsisShort")]
        public string SynopsisShort { get; set; }

        [JsonPropertyName("synopsis")]
        public string Synopsis { get; set; }

        [JsonPropertyName("castMember")]
        public List<CastMember> CastMemberList { get; set; }

        [JsonPropertyName("link")]
        public List<Link> LinkList { get; set; }

        [JsonPropertyName("statistics")]
        public Statistics Statistics { get; set; }

        public Error Error { get; set; }
    }
}
