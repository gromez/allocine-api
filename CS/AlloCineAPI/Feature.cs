using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
    public class Feature
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("publication")]
        public Publication Publication { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("picture")]
        public FeaturePicture Picture { get; set; }

        [JsonPropertyName("category")]
        public List<Category> CategoryList { get; set; }

    }
}
