using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    public class Writer
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "avatar")]
        public string Avatar { get; set; }
    }
}
