using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "parentFestival")]
    public class ParentFestival
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}

