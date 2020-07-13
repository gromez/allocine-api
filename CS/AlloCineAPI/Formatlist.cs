using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AlloCine
{
    [DataContract(Name = "formatList")]
    public class Formatlist
    {
        [DataMember(Name = "productionFormat")]
        public List<ProductionFormat> ProductionFormatList { get; set; }

        [DataMember(Name = "projectionFormat")]
        public List<ProjectionFormat> ProjectionFormatList { get; set; }

        [DataMember(Name = "soundFormat")]
        public List<SoundFormat> SoundFormatList { get; set; }
    }
}

