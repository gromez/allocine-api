using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    public class Rating
    {
        [DataMember(Name = "note")]
        public float Note { get; set; }

        [DataMember(Name = "INVALID_MEMBER_NAME")]
        public string Value { get; set; }
    }
}
