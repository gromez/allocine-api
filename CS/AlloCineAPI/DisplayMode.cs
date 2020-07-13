using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    public class DisplayMode
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }
    }
}
