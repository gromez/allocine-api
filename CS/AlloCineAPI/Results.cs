using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    public class Results
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "$")]
        public int Value { get; set; }
    }
}

