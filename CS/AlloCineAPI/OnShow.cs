using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    public class OnShow
    {
        [DataMember(Name = "movie")]
        public Movie Movie { get; set; }
    }
}