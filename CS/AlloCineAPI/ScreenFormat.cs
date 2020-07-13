using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    public class ScreenFormat
    {
        [DataMember(Name = "code")]
        public int Type { get; set; }

        [DataMember(Name = "INVALID_MEMBER_NAME")]
        public string Value { get; set; }
    }
}
