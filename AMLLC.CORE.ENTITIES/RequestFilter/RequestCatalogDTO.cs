using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.ENTITIES
{
    [DataContract]
    public class RequestCatalogDTO
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public bool IncludeDisabled { get; set; }
    }
}
