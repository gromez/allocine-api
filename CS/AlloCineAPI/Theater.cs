using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract]
    public class Theater
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("subway")]
        public string Subway { get; set; }

        [JsonPropertyName("cinemaChain")]
        public CinemaChain CinemaChain { get; set; }

        [JsonPropertyName("screenCount")]
        public int ScreenCount { get; set; }

        [JsonPropertyName("geoloc")]
        public Geoloc Geoloc { get; set; }

        [JsonPropertyName("picture")]
        public Picture Picture { get; set; }

        [JsonPropertyName("hasPRMAccess")]
        public int HasPRMAccess { get; set; }

        [JsonPropertyName("link")]
        public List<Link> LinkList { get; set; }







    }
}
