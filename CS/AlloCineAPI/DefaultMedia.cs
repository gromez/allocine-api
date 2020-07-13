using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    public class DefaultMedia
    {
        [DataMember(Name = "media")]
        public Media Media { get; set; }
    }
}

