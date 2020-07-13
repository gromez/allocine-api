using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "picture")]
    public class Picture
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "path")]
        public string Path { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }
    }
}