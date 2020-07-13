using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Allocine.ExtensionMethods;

namespace AlloCine
{
    [DataContract(Name = "person")]
    public class PersonLight
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "realName")]
        public string RealName { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "gender")]
        public string Gender { get; set; }

        [DataMember(Name = "birthDate")]
        private string BirthDateString
        {
            get { throw new NotImplementedException(); }
            set { BirthDate = value.toDate(); }
        }
        public DateTime BirthDate { get; set; }

        [DataMember(Name = "deathDate")]
        private string DeathDateString
        {
            get { throw new NotImplementedException(); }
            set { DeathDate = value.toDate(); }
        }
        public DateTime DeathDate { get; set; }

        [DataMember(Name = "activity")]
        public List<Activity> ActivityList { get; set; }

        [DataMember(Name = "nationality")]
        public List<Nationality> NationalityList { get; set; }

        [DataMember(Name = "picture")]
        public List<Picture> PictureList { get; set; }

        [DataMember(Name = "link")]
        public List<Link> LinkList { get; set; }


    }
}

