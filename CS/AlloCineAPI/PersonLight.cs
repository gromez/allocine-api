using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Allocine.ExtensionMethods;

namespace AlloCine
{
    [DataContract(Name = "person")]
    public class PersonLight
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("realName")]
        public string RealName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("birthDate")]
        private string BirthDateString
        {
            get { throw new NotImplementedException(); }
            set { BirthDate = value.toDate(); }
        }
        public DateTime BirthDate { get; set; }

        [JsonPropertyName("deathDate")]
        private string DeathDateString
        {
            get { throw new NotImplementedException(); }
            set { DeathDate = value.toDate(); }
        }
        public DateTime DeathDate { get; set; }

        [JsonPropertyName("activity")]
        public List<Activity> ActivityList { get; set; }

        [JsonPropertyName("nationality")]
        public List<Nationality> NationalityList { get; set; }

        [JsonPropertyName("picture")]
        public List<Picture> PictureList { get; set; }

        [JsonPropertyName("link")]
        public List<Link> LinkList { get; set; }


    }
}

