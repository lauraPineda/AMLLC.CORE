using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.ENTITIES.Catalog
{
    [DataContract]
    public class RequestProyectDTO
    {
        [DataMember]
        public int IdCompany { get; set; }
        [DataMember]
        public int IdClient { get; set; }
        [DataMember]
        public RequestCatalogDTO Proyect { get; set; }
    }
}
