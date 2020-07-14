using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Allocine.ExtensionMethods;

namespace AlloCine
{
    [DataContract(Name = "originalBroadcast")]
    public class OriginalBroadcast
    {
        //[JsonPropertyName("dateStart")]
        //public string DateStart { get; set; }

        [JsonPropertyName("dateStart")]
        private string DateStartString
        {
            get { throw new NotImplementedException(); }
            set { DateStart = value.toDate(); }
        }
        public DateTime DateStart { set; get; }
    }
}