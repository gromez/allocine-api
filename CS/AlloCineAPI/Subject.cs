using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    public class Subject
    {
        [DataMember(Name = "scheme")]
        public string Scheme { get; set; }

        [DataMember(Name = "code")]
        public int Code { get; set; }
    }
}
