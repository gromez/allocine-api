using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    public class T
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "p")]
        public int P { get; set; }

        [DataMember(Name = "INVALID_MEMBER_NAME")]
        public string Value { get; set; }
    }
}