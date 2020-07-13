using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "movieType")]
    public class MovieType
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "$")]
        public string Value { get; set; }
    }
}