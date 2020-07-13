using System;
using System.Runtime.Serialization;
using Allocine.ExtensionMethods;

namespace AlloCine
{
    [DataContract]
    public class HelpfulNegativeReview
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "creationDate")]
        private string CreationDateString
        {
            get { throw new NotImplementedException(); }
            set { CreationDate = value.toDate(); }
        }
        public DateTime CreationDate { get; set; }

        [DataMember(Name = "writer")]
        public Writer Writer { get; set; }

        [DataMember(Name = "body")]
        public string Body { get; set; }

        [DataMember(Name = "rating")]
        public float Rating { get; set; }

    }
}
