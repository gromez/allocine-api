using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
        public class Version
        {
            [JsonPropertyName("original")]
            public string Original { get; set; }

            [JsonPropertyName("code")]
            public int Code { get; set; }

            [JsonPropertyName("lang")]
            public int Lang { get; set; }

            [JsonPropertyName("INVALID_MEMBER_NAME")]
            public string Value { get; set; }
        }
}

