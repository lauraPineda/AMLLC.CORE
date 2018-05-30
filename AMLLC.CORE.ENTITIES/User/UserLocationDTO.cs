using AMLLC.CORE.ENTITIES.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.ENTITIES.User
{
    [DataContract]
    public class UserLocationDTO
    {
        [DataMember]
        public UserDTO User { get; set; }
        [DataMember]
        public InfoDTO Info { get; set; }
        [DataMember]
        public RoleDTO Role { get; set; }
        [DataMember]
        public LocationDTO Location { get; set; }

    }
}
