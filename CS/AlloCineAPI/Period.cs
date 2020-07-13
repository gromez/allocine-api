using System;
using System.Runtime.Serialization;
using Allocine.ExtensionMethods;

namespace AlloCine
{
    [DataContract(Name = "period")]
    public class Period
    {
        [DataMember(Name = "dateStart")]
        private string DateStartString
        {
            get { throw new NotImplementedException(); }
            set { DateStart = value.toDate(); }
        }
        public DateTime DateStart { get; set; }

        [DataMember(Name = "dateEnd")]
        private string DateEndString
        {
            get { throw new NotImplementedException(); }
            set { DateEnd = value.toDate(); }
        }
        public DateTime DateEnd { get; set; }
    }
}

