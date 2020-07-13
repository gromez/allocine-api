using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
    public class Media
    {
        [JsonPropertyName("class")]
        public string Class { get; set; }

        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("rcode")]
        public int Rcode { get; set; }

        [JsonPropertyName("type")]
        public Type Type { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("rendition")]
        public List<Rendition> RenditionList { get; set; }

        [JsonPropertyName("publication")]
        public Publication Publication { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        [JsonPropertyName("copyrightHolder")]
        public string CopyrightHolder { get; set; }

        public Error Error { get; set; }
    }
}
