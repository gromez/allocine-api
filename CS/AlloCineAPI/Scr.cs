using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Allocine.ExtensionMethods;

namespace AlloCine
{
    [DataContract]
    public class Scr
    {
        [DataMember(Name = "d")]
        private string DString
        {
            get { throw new NotImplementedException(); }
            set { D = value.toDate(); }
        }
        public DateTime D { get; set; }

        [DataMember(Name = "t")]
        public List<T> T { get; set; }
    }
}
