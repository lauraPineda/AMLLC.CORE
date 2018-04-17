using System;
using System.Runtime.Serialization;

namespace AMLLC.CORE.ENTITIES.DB
{
    [DataContract]
    public class RoleDTO
    {
        [DataMember]
        public UInt16 IdRole { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
