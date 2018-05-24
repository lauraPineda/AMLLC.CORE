using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.Catalog;
using AMLLC.CORE.ENTITIES.DB;
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

        public ResponseDTO<List<CatalogsDTO>> GetListCatalog(RequestCatalogDTO request, Catalogs catalog)
        {
            ResponseDTO<List<CatalogsDTO>> response;
            
            switch (catalog)
            {
                case Catalogs.Company:
                    uspCatalog = "[CLIENT].[USP_GET_COMPANIES]";
                    break;
                case Catalogs.Roles:
                    uspCatalog = "[USER].[USP_GET_ROLES]";
                    break;
            }

            response = catalogDataManager.GetListCatalog(request, uspCatalog);

            return response;
        }

        public ResponseDTO<List<CatalogsDTO>> GetListCompanyClients(RequestCompanyClientsDTO request)
        {
            ResponseDTO<List<CatalogsDTO>> response = catalogDataManager.GetListCompanyClients(request);

            return response;
        }

        public ResponseDTO<List<ProjectDTO>> GetClientProjects(RequestClientProjectDTO request)
        {
            ResponseDTO<List<ProjectDTO>> response = catalogDataManager.GetListClientProjects(request);

            return response;
        }
        public ResponseDTO<List<LocationDTO>> GetProjectsLocations(RequestProjectLocationsDTO request)
        {
            ResponseDTO<List<LocationDTO>> response = catalogDataManager.GetListProjectLocations(request);

            return response;
        }

        public ResponseDTO<List<InfoDTO>> GetLocationSupervisors(RequestLocationSupervisorsDTO request)
        {
            ResponseDTO<List<InfoDTO>> response = catalogDataManager.GetListLocationSupervisors(request);

            return response;
        }


        public ResponseDTO<List<InfoDTO>> GetSupervisorWorkers(UserDTO request)
        {
            ResponseDTO<List<InfoDTO>> response = catalogDataManager.GetListSupervisorsWorkers(request);

            return response;
        }


    }
}
