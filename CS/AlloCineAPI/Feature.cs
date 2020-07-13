using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    public class Feature
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "publication")]
        public Publication Publication { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "picture")]
        public FeaturePicture Picture { get; set; }

        [DataMember(Name = "category")]
        public List<Category> CategoryList { get; set; }

    }
}
