using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Allocine.ExtensionMethods;

namespace AlloCine
{
    [DataContract]
    public class Scr
    {
        [JsonPropertyName("d")]
        private string DString
        {
            get { throw new NotImplementedException(); }
            set { D = value.toDate(); }
        }
        public DateTime D { get; set; }

        [JsonPropertyName("t")]
        public List<T> T { get; set; }
    }
}
