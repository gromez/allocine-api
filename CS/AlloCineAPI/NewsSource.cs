using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    public class NewsSource
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }
    }
}
