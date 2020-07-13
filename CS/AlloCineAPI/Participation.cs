using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "participation")]
    public class Participation
    {
        [DataMember(Name = "movie")]
        public Movie Movie { get; set; }

        [DataMember(Name = "activity")]
        public Activity Activity { get; set; }

        [DataMember(Name = "role")]
        public string Role { get; set; }
    }
}

