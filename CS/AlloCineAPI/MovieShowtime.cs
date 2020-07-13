using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    public class MovieShowtime
    {
        [DataMember(Name = "preview")]
        public string Preview { get; set; }

        [DataMember(Name = "releaseWeek")]
        public string ReleaseWeek { get; set; }

        [DataMember(Name = "onShow")]
        public OnShow OnShow { get; set; }

        [DataMember(Name = "version")]
        public Version Version { get; set; }

        [DataMember(Name = "screenFormat")]
        public ScreenFormat ScreenFormat { get; set; }

        [DataMember(Name = "display")]
        public string Display { get; set; }

        [DataMember(Name = "scr")]
        public List<Scr> ScrList { get; set; }
    }
}

