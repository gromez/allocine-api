using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "statistics")]
    public class Statistics
    {
        [DataMember(Name = "pressRating")]
        public float PressRating { get; set; }

        [DataMember(Name = "pressReviewCount")]
        public int PressReviewCount { get; set; }

        [DataMember(Name = "userRating")]
        public float UserRating { get; set; }

        [DataMember(Name = "userReviewCount")]
        public int UserReviewCount { get; set; }

        [DataMember(Name = "userRatingCount")]
        public int UserRatingCount { get; set; }

        [DataMember(Name = "averageViewerCount")]
        public int AverageViewerCount { get; set; }

        [DataMember(Name = "editorialRatingCount")]
        public int EditorialRatingCount { get; set; }
        
        [DataMember(Name = "commentCount")]
        public int CommentCount { get; set; }

        [DataMember(Name = "photoCount")]
        public int PhotoCount { get; set; }

        [DataMember(Name = "videoCount")]
        public int VideoCount { get; set; }

        [DataMember(Name = "triviaCount")]
        public int TriviaCount { get; set; }

        [DataMember(Name = "newsCount")]
        public int newsCount { get; set; }

        [DataMember(Name = "rankTopMovie")]
        public int RankTopMovie { get; set; }

        [DataMember(Name = "variationTopMovie")]
        public int VariationTopMovie { get; set; }

        [DataMember(Name = "awardCount")]
        public int AwardCount { get; set; }

        [DataMember(Name = "nominationCount")]
        public int NominationCount { get; set; }

        [DataMember(Name = "rating")]
        public List<Rating> RatingList { get; set; }

        [DataMember(Name = "ratingStats")]
        public List<RatingStats> RatingStats { get; set; }

        [DataMember(Name = "fanCount")]
        public int FanCount { get; set; }

        [DataMember(Name = "wantToSeeCount")]
        public int WantToSeeCount { get; set; }

        [DataMember(Name = "releaseWeekPosition")]
        public int ReleaseWeekPosition { get; set; }

        [DataMember(Name = "admissionCount")]
        public int AdmissionCount { get; set; }

        [DataMember(Name = "theaterCount")]
        public int TheaterCount { get; set; }

        [DataMember(Name = "theaterCountOnRelease")]
        public string TheaterCountOnRelease { get; set; }

    }
}