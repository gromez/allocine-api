using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract(Name = "statistics")]
    public class Statistics
    {
        [JsonPropertyName("pressRating")]
        public float PressRating { get; set; }

        [JsonPropertyName("pressReviewCount")]
        public int PressReviewCount { get; set; }

        [JsonPropertyName("userRating")]
        public float UserRating { get; set; }

        [JsonPropertyName("userReviewCount")]
        public int UserReviewCount { get; set; }

        [JsonPropertyName("userRatingCount")]
        public int UserRatingCount { get; set; }

        [JsonPropertyName("averageViewerCount")]
        public int AverageViewerCount { get; set; }

        [JsonPropertyName("editorialRatingCount")]
        public int EditorialRatingCount { get; set; }
        
        [JsonPropertyName("commentCount")]
        public int CommentCount { get; set; }

        [JsonPropertyName("photoCount")]
        public int PhotoCount { get; set; }

        [JsonPropertyName("videoCount")]
        public int VideoCount { get; set; }

        [JsonPropertyName("triviaCount")]
        public int TriviaCount { get; set; }

        [JsonPropertyName("newsCount")]
        public int newsCount { get; set; }

        [JsonPropertyName("rankTopMovie")]
        public int RankTopMovie { get; set; }

        [JsonPropertyName("variationTopMovie")]
        public int VariationTopMovie { get; set; }

        [JsonPropertyName("awardCount")]
        public int AwardCount { get; set; }

        [JsonPropertyName("nominationCount")]
        public int NominationCount { get; set; }

        [JsonPropertyName("rating")]
        public List<Rating> RatingList { get; set; }

        [JsonPropertyName("ratingStats")]
        public List<RatingStats> RatingStats { get; set; }

        [JsonPropertyName("fanCount")]
        public int FanCount { get; set; }

        [JsonPropertyName("wantToSeeCount")]
        public int WantToSeeCount { get; set; }

        [JsonPropertyName("releaseWeekPosition")]
        public int ReleaseWeekPosition { get; set; }

        [JsonPropertyName("admissionCount")]
        public int AdmissionCount { get; set; }

        [JsonPropertyName("theaterCount")]
        public int TheaterCount { get; set; }

        [JsonPropertyName("theaterCountOnRelease")]
        public string TheaterCountOnRelease { get; set; }

    }
}