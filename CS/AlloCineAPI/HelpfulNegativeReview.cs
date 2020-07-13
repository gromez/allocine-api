using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Allocine.ExtensionMethods;

namespace AlloCine
{
    [DataContract]
    public class HelpfulNegativeReview
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

        [JsonPropertyName("writer")]
        public Writer Writer { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("rating")]
        public float Rating { get; set; }

    }
}
