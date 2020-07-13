using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    public class Link
    {
        [DataMember(Name = "rel")]
        public string Rel { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }
    }
}
