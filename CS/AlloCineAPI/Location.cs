using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    public class Location
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "parent")]
        public Parent Parent { get; set; }

        [DataMember(Name = "locationType")]
        public LocationType LocationType { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "postalCode")]
        public string PostalCode { get; set; }

        [DataMember(Name = "geoloc")]
        public Geoloc Geoloc { get; set; }







    }
}
