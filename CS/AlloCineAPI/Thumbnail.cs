using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "thumbnail")]
    public class Thumbnail
    {
        [DataMember(Name = "path")]
        public string Path { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }
    }
}

