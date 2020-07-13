using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    internal class AllocineObjectModel
    {
        [DataMember(Name = "error")]
        public Error Error = new Error();

        [DataMember(Name = "movie")]
        public Movie Movie = new Movie();

        [DataMember(Name = "feed")]
        public Feed Feed = new Feed();

        [DataMember(Name = "person")]
        public Person Person = new Person();

        [DataMember(Name = "media")]
        public Media Media = new Media();

        [DataMember(Name = "tvseries")]
        public TvSeries TvSeries = new TvSeries();

        [DataMember(Name = "season")]
        public Season Season = new Season();

        [DataMember(Name = "episode")]
        public Episode Episode = new Episode();
    }
}
