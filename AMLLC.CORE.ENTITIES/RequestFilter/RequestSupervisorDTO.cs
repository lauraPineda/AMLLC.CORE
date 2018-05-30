using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.ENTITIES.RequestFilter
{
    [DataContract]
    public class RequestSupervisorDTO
    {
        [DataMember]
        public int IdLocation { get; set; }
        [DataMember]
        public int SupervisedIdRole { get; set; }
        [DataMember]
        public int IdUser { get; set; }
        [DataMember]
        public Boolean IncludeDisabled { get; set; }
    }
}
