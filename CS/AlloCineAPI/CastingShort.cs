using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "castingShort")]
    public class CastingShort
    {
        [DataMember(Name = "directors")]
        public string Directors { get; set; }

        [DataMember(Name = "actors")]
        public string Actors { get; set; }

        [DataMember(Name = "creators")]
        public string Creators { get; set; }

    }
}