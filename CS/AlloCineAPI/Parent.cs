using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "parent")]
    public class Parent
    {
        [DataMember(Name = "scheme")]
        public string Scheme { get; set; }

        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

    }
}

