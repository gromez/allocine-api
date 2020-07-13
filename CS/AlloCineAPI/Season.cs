using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "season")]
    public class Season
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "parentSeries")]
        public ParentSeries ParentSeries { get; set; }

        [DataMember(Name = "seasonNumber")]
        public int SeasonNumber { get; set; }

        [DataMember(Name = "episodeCount")]
        public int EpisodeCount { get; set; }

        [DataMember(Name = "productionStatus")]
        public ProductionStatus ProductionStatus { get; set; }

        [DataMember(Name = "yearStart")]
        public int YearStart { get; set; }

        [DataMember(Name = "yearEnd")]
        public int YearEnd { get; set; }

        [DataMember(Name = "trailerEmbed")]
        public string TrailerEmbed { get; set; }

        [DataMember(Name = "castMember")]
        public List<CastMember> CastMemberList { get; set; }

        [DataMember(Name = "episode")]
        public List<Episode> EpisodeList { get; set; }

        [DataMember(Name = "link")]
        public List<Link> LinkList { get; set; }

        [DataMember(Name = "media")]
        public List<Media> MediaList { get; set; }

        [DataMember(Name = "statistics")]
        public Statistics Statistics { get; set; }

        public Error Error { get; set; }
    }
}
