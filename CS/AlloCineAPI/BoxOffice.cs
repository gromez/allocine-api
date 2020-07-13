using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    public class BoxOffice
    {
        [DataMember(Name = "type")]
        public Type Type { get; set; }

        [DataMember(Name = "country")]
        public Country Country { get; set; }

        [DataMember(Name = "period")]
        public Period Period { get; set; }

        [DataMember(Name = "week")]
        public int Week { get; set; }

        [DataMember(Name = "gross")]
        public string Gross { get; set; }

        [DataMember(Name = "grossTotal")]
        public string GrossTotal { get; set; }

        //[DataMember(Name = "currency")]
        //public string Currency { get; set; }

        [DataMember(Name = "currency")]
        public Currency Currency { get; set; }

        [DataMember(Name = "admissionCount")]
        public int AdmissionCount { get; set; }

        [DataMember(Name = "admissionCountTotal")]
        public int AdmissionCountTotal { get; set; }

        [DataMember(Name = "copyCount")]
        public int CopyCount { get; set; }

    }
}
