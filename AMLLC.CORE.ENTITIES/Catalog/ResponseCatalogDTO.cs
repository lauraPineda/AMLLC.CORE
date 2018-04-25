using System.Runtime.Serialization;

namespace AMLLC.CORE.ENTITIES
{
    [DataContract]
    public class ResponseCatalogDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public bool Enabled { get; set; }
    }
}
