using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "productionStatus")]
    public class ProductionStatus
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "$")]
        public string Value { get; set; }
    }
}
