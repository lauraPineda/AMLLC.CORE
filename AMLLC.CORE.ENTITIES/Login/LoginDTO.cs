
using AMLLC.CORE.ENTITIES.DB;
using System.Runtime.Serialization;

namespace AMLLC.CORE.ENTITIES.Login
{
    [DataContract]
    public class LoginDTO
    {
        [DataMember]
        public UserDTO User { get; set; }
        [DataMember]
        public RoleDTO Role { get; set; }
        [DataMember]
        public InfoDTO Info { get; set; }
        [DataMember]
        public bool IsAuthenticated { get; set; }
    }
}
