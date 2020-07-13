using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "ratingStats")]
    public class RatingStats
    {
        [DataMember(Name = "note")]
        public string Note { get; set; }

        [DataMember(Name = "$")]
        public string Value { get; set; }
    }
}
