using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract(Name = "castMember")]
    public class CastMember
    {
        [JsonPropertyName("person")]
        public PersonLight Person { get; set; }

        [JsonPropertyName("activity")]
        public Activity Activity { get; set; }

        [JsonPropertyName("picture")]
        public Picture Picture { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("isLeadActor")]
        public string IsLeadActor { get; set; }
    }
}
