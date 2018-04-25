using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.ENTITIES.Catalog
{
    [DataContract]
    public class RequestCompanyClientsDTO
    {
        [DataMember]
        public int IdCompany { get; set; }
        [DataMember]
        public RequestCatalogDTO Client { get; set; }
    }
}
