using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
        public bool HasTelephone { get; set; }
    }
}

