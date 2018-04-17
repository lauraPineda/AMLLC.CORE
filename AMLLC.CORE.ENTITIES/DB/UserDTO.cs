using System.Runtime.Serialization;

namespace AMLLC.CORE.ENTITIES.DB
{
    [DataContract]
    public class UserDTO
    {
        [DataMember]
        public uint IdUser { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
