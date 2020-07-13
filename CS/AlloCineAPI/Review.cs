using System;
using System.Runtime.Serialization;
using Allocine.ExtensionMethods;

namespace AlloCine
{
    [DataContract]
    public class Review
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

        [DataMember(Name = "type")]
        public Type Type { get; set; }

        [DataMember(Name = "subject")]
        public Subject Subject { get; set; }

        [DataMember(Name = "newsSource")]
        public NewsSource NewsSource { get; set; }

        [DataMember(Name = "author")]
        public string Author { get; set; }

        [DataMember(Name = "reviewUrl")]
        public ReviewUrl ReviewUrl { get; set; }

        [DataMember(Name = "body")]
        public string Body { get; set; }

        [DataMember(Name = "rating")]
        public string Rating { get; set; }

    }
}
