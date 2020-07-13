using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    public class ReviewUrl
    {
        [DataMember(Name = "href")]
        public string Href { get; set; }
    }
}
