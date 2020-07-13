using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Allocine.ExtensionMethods;

namespace AlloCine
{
    [DataContract(Name = "person")]
    public class Person
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("name")]
        public NameGivenFamily NameGivenFamily { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("nationality")]
        public List<Nationality> NationalityList { get; set; }

        [JsonPropertyName("activity")]
        public List<Activity> ActivityList { get; set; }

        [JsonPropertyName("activityShort")]
        public string ActivityShort { get; set; }

        [JsonPropertyName("biographyShort")]
        public string BiographyShort { get; set; }

        [JsonPropertyName("biography")]
        public string Biography { get; set; }

        [JsonPropertyName("birthDate")]
        private string BirthDateString
        {
            get { throw new NotImplementedException(); }
            set { BirthDate = value.toDate(); }
        }
        public DateTime BirthDate { get; set; }

        [JsonPropertyName("birthPlace")]
        public string BirthPlace { get; set; }

        [JsonPropertyName("picture")]
        public Picture Picture { get; set; }

        [JsonPropertyName("link")]
        public List<Link> LinkList { get; set; }

        [JsonPropertyName("participation")]
        public List<Participation> ParticipationList { get; set; }

        [JsonPropertyName("media")]
        public List<Media> MediaList { get; set; }

        [JsonPropertyName("news")]
        public List<News> NewsList { get; set; }

        public Error Error { get; set; }
    }
}

