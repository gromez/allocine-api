using System;
using System.Globalization;
using System.Runtime.Serialization;
using Allocine.ExtensionMethods;

namespace AlloCine
{
    [DataContract(Name = "originalBroadcast")]
    public class OriginalBroadcast
    {
        //[DataMember(Name = "dateStart")]
        //public string DateStart { get; set; }

        [DataMember(Name = "dateStart")]
        private string DateStartString
        {
            get { throw new NotImplementedException(); }
            set { DateStart = value.toDate(); }
        }
        public DateTime DateStart { set; get; }
    }
}