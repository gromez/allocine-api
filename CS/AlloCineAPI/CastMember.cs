using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "castMember")]
    public class CastMember
    {
        [DataMember(Name = "person")]
        public PersonLight Person { get; set; }

        [DataMember(Name = "activity")]
        public Activity Activity { get; set; }

        [DataMember(Name = "picture")]
        public Picture Picture { get; set; }

        [DataMember(Name = "role")]
        public string Role { get; set; }

        [DataMember(Name = "isLeadActor")]
        public string IsLeadActor { get; set; }
    }
}
