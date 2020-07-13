using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
    public class Trivia
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("publication")]
        public Publication Publication { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

    }
}
