using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    public class Trivia
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "publication")]
        public Publication Publication { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "body")]
        public string Body { get; set; }

    }
}
