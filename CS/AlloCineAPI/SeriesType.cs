using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract(Name = "seriesType")]
    public class SeriesType
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("INVALID_MEMBER_NAME")]
        public string Value { get; set; }
    }
}
