using Microsoft.SqlServer.Types;
using System.Runtime.Serialization;

namespace AMLLC.CORE.ENTITIES.DB
{
    [DataContract]
    public class LocationDTO
    {
        [DataMember]
        public int IdLocation { get; set; }
        [DataMember]
        public int IdProject { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public float Longitude { get; set; }
        [DataMember]
        public float Latitude { get; set; }
        [DataMember]
        public SqlGeography GeoSpacial { get; set; }

    }
}
