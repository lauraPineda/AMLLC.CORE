using System.Runtime.Serialization;

namespace AMLLC.CORE.ENTITIES.Catalog
{
    [DataContract]
    public class RequestLocationSupervisorsDTO
    {
        [DataMember]
        public int IdLocation { get; set; }
        [DataMember]
        public int IdSupervisedRol { get; set; }
    }
}
