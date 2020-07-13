using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    public class Rendition
    {
        [DataMember(Name = "path")]
        public string Path { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }

        [DataMember(Name = "format")]
        public Format Format { get; set; }

    }
}
