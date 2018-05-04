using System;
using System.Runtime.Serialization;

namespace AMLLC.CORE.ENTITIES.DB
{
    [DataContract]
    public class InfoDTO
    {
        [DataMember]
        public uint IdInfo { get; set; }
        [DataMember]
        public uint IdUser { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Telephone { get; set; }
        [DataMember]
        public Boolean HasTelephone { get; set; }
    }
}

