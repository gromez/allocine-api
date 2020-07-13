using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "parentEdition")]
    public class ParentEdition
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}

