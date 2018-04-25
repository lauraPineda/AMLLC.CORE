using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.BUSINESS.Client
{
    public class ClientLogic
    {

        ProjectDataManager projectDataManager;


        public ClientLogic()
        {
            projectDataManager = new ProjectDataManager();
        }

        public ResponseDTO<List<ResponseCatalogDTO>> GetListCatalog(RequestClientProjectDTO request)
        {
            ResponseDTO<List<ResponseCatalogDTO>> response = projectDataManager.GetListClientProjects(request);

            return response;
        }
    }
}
