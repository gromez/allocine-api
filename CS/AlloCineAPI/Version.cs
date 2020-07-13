using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
        public class Version
        {
            [DataMember(Name="original")]
            public string Original { get; set; }

            [DataMember(Name="code")]
            public int Code { get; set; }

            [DataMember(Name="lang")]
            public int Lang { get; set; }

            [DataMember(Name="$")]
            public string Value { get; set; }
        }
}

