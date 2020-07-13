using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "trailer")]
    public class Trailer
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }
    }
}

