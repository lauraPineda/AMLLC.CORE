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
    public class UserRequestDTO
    {
        [DataMember]
        public UserDTO User { get; set; }
        [DataMember]
        public InfoDTO Info { get; set; }
    }
}
