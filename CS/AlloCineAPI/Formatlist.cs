using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlloCine
{
    [DataContract(Name = "formatList")]
    public class Formatlist
    {
        [JsonPropertyName("productionFormat")]
        public List<ProductionFormat> ProductionFormatList { get; set; }

        [JsonPropertyName("projectionFormat")]
        public List<ProjectionFormat> ProjectionFormatList { get; set; }

        [JsonPropertyName("soundFormat")]
        public List<SoundFormat> SoundFormatList { get; set; }
    }
}

