using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
    public class News
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("publication")]
        public Publication Publication { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("picture")]
        public NewsPicture Picture { get; set; }

        [JsonPropertyName("displayMode")]
        public DisplayMode DisplayMode { get; set; }

        [JsonPropertyName("category")]
        public List<Category> CategoryList { get; set; }

        [JsonPropertyName("headline")]
        public string Headline { get; set; }

    }
}
