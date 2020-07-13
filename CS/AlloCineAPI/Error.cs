using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "error")]
    public class Error
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "INVALID_MEMBER_NAME")]
        public string Value { get; set; }
    }
}

