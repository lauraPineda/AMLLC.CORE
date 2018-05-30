using AMLLC.CORE.ENTITIES.DB;
using System.Runtime.Serialization;

namespace AMLLC.CORE.ENTITIES.User
{
    [DataContract]
    public class UserRequestDTO
    {
        [DataMember]
        public UserDTO User { get; set; }
        [DataMember]
        public InfoDTO Info { get; set; }
    }
}
