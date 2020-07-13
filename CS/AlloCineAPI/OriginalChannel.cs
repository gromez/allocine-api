using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "originalChannel")]
    public class OriginalChannel
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "$")]
        public string Value { get; set; }

        [DataMember(Name = "country")]
        public Country Country { get; set; }
    }
}
