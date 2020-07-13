using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    public class FestivalAward
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "parentFestival")]
        public ParentFestival ParentFestival { get; set; }

        [DataMember(Name = "parentEdition")]
        public ParentEdition ParentEdition { get; set; }

        [DataMember(Name = "awardType")]
        public AwardType AwardType { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

    }
}
