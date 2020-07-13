using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "locationType")]
    public class LocationType
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "INVALID_MEMBER_NAME")]
        public string Value { get; set; }
    }
}

