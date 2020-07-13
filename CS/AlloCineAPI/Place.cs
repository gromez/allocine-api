using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "place")]
    public class Place
    {
        [DataMember(Name = "theater")]
        public Theater Theater { get; set; }
    }
}
