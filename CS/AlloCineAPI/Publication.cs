using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Allocine.ExtensionMethods;

namespace AlloCine
{
    [DataContract(Name = "publication")]
    public class Publication
    {
        [JsonPropertyName("dateStart")]
        private string DateStartString
        {
            get { throw new NotImplementedException(); }
            set { DateStart = value.toDate(); }
        }
        public DateTime DateStart { get; set; }

    }
}