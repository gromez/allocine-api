using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "currency")]
    public class Currency
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }
    }
}

