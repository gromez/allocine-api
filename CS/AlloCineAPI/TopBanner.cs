using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "topBanner")]
    public class TopBanner
    {
        [DataMember(Name = "href")]
        public string Href { get; set; }
    }
}

