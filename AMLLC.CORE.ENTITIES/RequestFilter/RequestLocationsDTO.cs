using System.Runtime.Serialization;

namespace AMLLC.CORE.ENTITIES.Catalog
{
    [DataContract]
    public class RequestLocationsDTO
    {
        [DataMember]
        public int IdProject { get; set; }
        [DataMember]
        public RequestCatalogDTO Location { get; set; }
    }
}
