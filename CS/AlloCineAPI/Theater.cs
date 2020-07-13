using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract]
    public class Theater
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "postalCode")]
        public string PostalCode { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "subway")]
        public string Subway { get; set; }

        [DataMember(Name = "cinemaChain")]
        public CinemaChain CinemaChain { get; set; }

        [DataMember(Name = "screenCount")]
        public int ScreenCount { get; set; }

        [DataMember(Name = "geoloc")]
        public Geoloc Geoloc { get; set; }

        [DataMember(Name = "picture")]
        public Picture Picture { get; set; }

        [DataMember(Name = "hasPRMAccess")]
        public int HasPRMAccess { get; set; }

        [DataMember(Name = "link")]
        public List<Link> LinkList { get; set; }







    }
}
