using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "poster")]
    public class Poster
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }

        [DataMember(Name = "path")]
        public string Path { get; set; }
    }
}

