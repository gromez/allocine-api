using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
    public class BoxOffice
    {
        [JsonPropertyName("type")]
        public Type Type { get; set; }

        [JsonPropertyName("country")]
        public Country Country { get; set; }

        [JsonPropertyName("period")]
        public Period Period { get; set; }

        [JsonPropertyName("week")]
        public int Week { get; set; }

        [JsonPropertyName("gross")]
        public string Gross { get; set; }

        [JsonPropertyName("grossTotal")]
        public string GrossTotal { get; set; }

        //[JsonPropertyName("currency")]
        //public string Currency { get; set; }

        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }

        [JsonPropertyName("admissionCount")]
        public int AdmissionCount { get; set; }

        [JsonPropertyName("admissionCountTotal")]
        public int AdmissionCountTotal { get; set; }

        [JsonPropertyName("copyCount")]
        public int CopyCount { get; set; }

    }
}
