using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AMLLC.CORE.SHARED.CatalogEnum;

namespace AMLLC.CORE.BUSINESS
{
    public class CatalogLogic
    {
        CatalogDataManager catalogDataManager;
        string uspCatalog;

        public CatalogLogic()
        {
            catalogDataManager = new CatalogDataManager();
        }

        public ResponseDTO<List<ResponseCatalogDTO>> GetListCatalog(RequestCatalogDTO request, Catalogs catalog)
        {
            ResponseDTO<List<ResponseCatalogDTO>> response;
            
            switch (catalog)
            {
                case Catalogs.Company:
                    uspCatalog = "[CLIENT].[USP_GET_COMPANIES]";
                    break;
            }

            response = catalogDataManager.GetListCatalog(request, uspCatalog);

            return response;
        }
    }
}
