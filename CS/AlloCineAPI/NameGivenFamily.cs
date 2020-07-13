using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    public class NameGivenFamily
    {
        [DataMember(Name = "given")]
        public string Given { get; set; }

        [DataMember(Name = "family")]
        public string Family { get; set; }
    }
}
