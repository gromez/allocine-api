using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "movie")]
    public class Movie
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "movieType")]
        public MovieType MovieType { get; set; }

        [DataMember(Name = "originalTitle")]
        public string OriginalTitle { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "keywords")]
        public string Keywords { get; set; }

        [DataMember(Name = "productionYear")]
        public int ProductionYear { get; set; }

        [DataMember(Name = "nationality")]
        public List<Nationality> NationalityList { get; set; }

        [DataMember(Name = "genre")]
        public List<Genre> GenreList { get; set; }

        [DataMember(Name = "release")]
        public Release Release { get; set; }

        [DataMember(Name = "runtime")]
        public string Runtime { get; set; }

        [DataMember(Name = "color")]
        public Color Color { get; set; }

        [DataMember(Name = "formatList")]
        public Formatlist Formatlist { get; set; }

        [DataMember(Name = "language")]
        public List<Language> LanguageList { get; set; }

        [DataMember(Name = "budget")]
        public string Budget { get; set; }

        [DataMember(Name = "synopsis")]
        public string Synopsis { get; set; }

        [DataMember(Name = "synopsisShort")]
        public string SynopsisShort { get; set; }

        [DataMember(Name = "castingShort")]
        public CastingShort CastingShort { get; set; }

        [DataMember(Name = "castMember")]
        public List<CastMember> CastMemberList { get; set; }

        [DataMember(Name = "poster")]
        public Poster Poster { get; set; }

        [DataMember(Name = "trailer")]
        public Trailer Trailer { get; set; }

        [DataMember(Name = "trailerEmbed")]
        public string TrailerEmbed { get; set; }

        [DataMember(Name = "defaultMedia")]
        public DefaultMedia DefaultMedia { get; set; }

        [DataMember(Name = "hasShowtime")]
        public int HasShowtime { get; set; }

        [DataMember(Name = "link")]
        public List<Link> LinkList { get; set; }

        [DataMember(Name = "media")]
        public List<Media> MediaList { get; set; }

        [DataMember(Name = "statistics")]
        public Statistics Statistics { get; set; }

        [DataMember(Name = "news")]
        public List<News> NewsList { get; set; }

        [DataMember(Name = "feature")]
        public List<Feature> FeatureList { get; set; }

        [DataMember(Name = "trivia")]
        public List<Trivia> TriviaList { get; set; }

        [DataMember(Name = "tag")]
        public List<Tag> TagList { get; set; }

        [DataMember(Name = "festivalAward")]
        public List<FestivalAward> FestivalAwardList { get; set; }

        [DataMember(Name = "boxOffice")]
        public List<BoxOffice> BoxOfficeList { get; set; }

        [DataMember(Name = "helpfulPositiveReview")]
        public List<HelpfulPositiveReview> HelpfulPositiveReviewList { get; set; }

        [DataMember(Name = "helpfulNegativeReview")]
        public List<HelpfulNegativeReview> HelpfulNegativeReviewList { get; set; }

        public Error Error { get; set; }

    }
}
