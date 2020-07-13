using System;
using System.Runtime.Serialization;
using Allocine.ExtensionMethods;

namespace AlloCine
{
    [DataContract(Name = "release")]
    public class Release
    {
        [DataMember(Name = "releaseDate")]
        private string ReleaseDateString
        {
            get { throw new NotImplementedException(); }
            set { ReleaseDate = value.toDate(); }
        }
        public DateTime ReleaseDate { get; set; }

        [DataMember(Name = "reissueDate")]
        private string ReissueDateString
        {
            get { throw new NotImplementedException(); }
            set { ReissueDate = value.toDate(); }
        }
        public DateTime ReissueDate { get; set; }

        [DataMember(Name = "country")]
        public Country Country { get; set; }

        [DataMember(Name = "releaseState")]
        public ReleaseState ReleaseState { get; set; }

        [DataMember(Name = "distributor")]
        public Distributor Distributor { get; set; }

    }
}
