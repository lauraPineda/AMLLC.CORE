using System;
using System.Runtime.Serialization;

namespace AMLLC.CORE.ENTITIES.DB
{
    [DataContract]
    public class UserDTO
    {
        public UserDTO()
        {
            Enabled = true;
        }
        public UserDTO(uint iIdUser)
        {
            IdUser = iIdUser;
            Enabled = true;
        }

        [DataMember]
        public uint IdUser { get; set; }
        [DataMember]
        public uint IdCompany { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public Boolean Enabled { get; set; }
    }
}
