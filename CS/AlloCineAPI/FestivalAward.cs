using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
    public class FestivalAward
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("parentFestival")]
        public ParentFestival ParentFestival { get; set; }

        [JsonPropertyName("parentEdition")]
        public ParentEdition ParentEdition { get; set; }

        [JsonPropertyName("awardType")]
        public AwardType AwardType { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

    }
}
