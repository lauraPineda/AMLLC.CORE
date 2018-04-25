using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.BUSINESS.Company
{
    public class CompanyLogic
    {
        CompanyDataManager CompanyDataManager;


        public CompanyLogic()
        {
            CompanyDataManager = new CompanyDataManager();
        }

        public ResponseDTO<List<ResponseCatalogDTO>> GetListCatalog(RequestCompanyClientsDTO request)
        {
            ResponseDTO<List<ResponseCatalogDTO>> response = CompanyDataManager.GetListCompanyClients(request);

            return response;
        }

    }
}
