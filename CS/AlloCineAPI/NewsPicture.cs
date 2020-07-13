using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    public class NewsPicture
    {
        [DataMember(Name = "path")]
        public string Path { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }
    }
}