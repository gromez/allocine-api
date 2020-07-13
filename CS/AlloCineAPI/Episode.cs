using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Allocine.ExtensionMethods;

namespace AlloCine
{
    [DataContract(Name = "episode")]
    public class Episode
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "parentSeries")]
        public ParentSeries ParentSeries { get; set; }

        [DataMember(Name = "parentSeason")]
        public ParentSeason ParentSeason { get; set; }

        [DataMember(Name = "originalTitle")]
        public string OriginalTitle { get; set; }

        [DataMember(Name = "originalBroadcastDate")]
        private string OriginalBroadcastDateString
        {
            get { throw new NotImplementedException(); }
            set { OriginalBroadcastDate = value.toDate(); }
        }
        public DateTime OriginalBroadcastDate { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "episodeNumberSeries")]
        public string EpisodeNumberSeries { get; set; }

        [DataMember(Name = "episodeNumberSeason")]
        public string EpisodeNumberSeason { get; set; }

        [DataMember(Name = "synopsisShort")]
        public string SynopsisShort { get; set; }

        [DataMember(Name = "synopsis")]
        public string Synopsis { get; set; }

        [DataMember(Name = "castMember")]
        public List<CastMember> CastMemberList { get; set; }

        [DataMember(Name = "link")]
        public List<Link> LinkList { get; set; }

        [DataMember(Name = "statistics")]
        public Statistics Statistics { get; set; }

        public Error Error { get; set; }
    }
}
