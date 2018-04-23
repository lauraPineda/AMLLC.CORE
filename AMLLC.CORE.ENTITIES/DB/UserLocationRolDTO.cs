using System;
using System.Runtime.Serialization;

namespace AMLLC.CORE.ENTITIES.DB
{
    [DataContract]

    public class UserLocationRolDTO
    {
        [DataMember]
        public Int64 IdUserLocationRole { get; set; }
        [DataMember]
        public int IdRole { get; set; }
        [DataMember]
        public int IdLocation { get; set; }
        [DataMember]
        public int IdUser { get; set; }
        [DataMember]
        public int IdUserSupervisor { get; set; }
    }
}
