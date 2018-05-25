using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.ENTITIES.RequestFilter
{
    [DataContract]
    public class CompanyFiltersDTO
    {
        [DataMember]
        public int IdCompany { get; set; }
        [DataMember]
        public RequestCatalogDTO Client { get; set; }
    }
}
