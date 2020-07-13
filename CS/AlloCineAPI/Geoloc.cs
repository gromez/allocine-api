using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "geoloc")]
    public class Geoloc
    {
        [DataMember(Name = "lat")]
        public string Lat { get; set; }

        [DataMember(Name = "long")]
        public string Long { get; set; }
    }
}

