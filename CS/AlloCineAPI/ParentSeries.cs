using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "parentSeries")]
    public class ParentSeries
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
