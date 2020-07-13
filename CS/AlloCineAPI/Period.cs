using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Allocine.ExtensionMethods;

namespace AlloCine
{
    [DataContract(Name = "period")]
    public class Period
    {
        [JsonPropertyName("dateStart")]
        private string DateStartString
        {
            get { throw new NotImplementedException(); }
            set { DateStart = value.toDate(); }
        }
        public DateTime DateStart { get; set; }

        [JsonPropertyName("dateEnd")]
        private string DateEndString
        {
            get { throw new NotImplementedException(); }
            set { DateEnd = value.toDate(); }
        }
        public DateTime DateEnd { get; set; }
    }
}

