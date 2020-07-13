using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Allocine.ExtensionMethods;

namespace AlloCine
{
    [DataContract]
    public class Review
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("creationDate")]
        private string CreationDateString
        {
            get { throw new NotImplementedException(); }
            set { CreationDate = value.toDate(); }
        }
        public DateTime CreationDate { get; set; }

        [JsonPropertyName("type")]
        public Type Type { get; set; }

        [JsonPropertyName("subject")]
        public Subject Subject { get; set; }

        [JsonPropertyName("newsSource")]
        public NewsSource NewsSource { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("reviewUrl")]
        public ReviewUrl ReviewUrl { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("rating")]
        public string Rating { get; set; }

    }
}
