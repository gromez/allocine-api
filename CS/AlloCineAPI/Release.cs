using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Allocine.ExtensionMethods;

namespace AlloCine
{
    [DataContract(Name = "release")]
    public class Release
    {
        [JsonPropertyName("releaseDate")]
        private string ReleaseDateString
        {
            get { throw new NotImplementedException(); }
            set { ReleaseDate = value.toDate(); }
        }
        public DateTime ReleaseDate { get; set; }

        [JsonPropertyName("reissueDate")]
        private string ReissueDateString
        {
            get { throw new NotImplementedException(); }
            set { ReissueDate = value.toDate(); }
        }
        public DateTime ReissueDate { get; set; }

        [JsonPropertyName("country")]
        public Country Country { get; set; }

        [JsonPropertyName("releaseState")]
        public ReleaseState ReleaseState { get; set; }

        [JsonPropertyName("distributor")]
        public Distributor Distributor { get; set; }

    }
}
