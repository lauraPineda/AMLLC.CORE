using AMLLC.CORE.DATA;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.Catalog;
using AMLLC.CORE.ENTITIES.DB;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AMLLC.CORE.SHARED.CatalogEnum;

namespace AMLLC.CORE.DATAMANAGER
{
    public class CatalogDataManager
    {
        MapperListCatalogDTO mapperListCatalogDTO;
        Database database;
        DatabaseType databaseType;
        public CatalogDataManager()
        {
            mapperListCatalogDTO = new MapperListCatalogDTO();
            databaseType = DatabaseType.SqlServer;
        }

        public ResponseDTO<List<CatalogsDTO>> GetListCatalog(RequestCatalogDTO request, string uspName)
        {
            database = DatabaseFactory.CreateDataBase(databaseType, uspName, request.IncludeDisabled, request.Id);

            ResponseDTO<List<CatalogsDTO>> response = mapperListCatalogDTO.Mapper(database.DataReader);

            database.Connection.Close();

            return response;
        }



        public ResponseDTO<List<CatalogsDTO>> GetListCompanyClients(RequestCompanyClientsDTO request)
        {

            database = DatabaseFactory.CreateDataBase(databaseType, "[CLIENT].[USP_GET_COMPANYCLIENTS]", request.IdCompany, request.Client.IncludeDisabled, request.Client.Id);

            ResponseDTO<List<CatalogsDTO>> response = mapperListCatalogDTO.Mapper(database.DataReader);

            database.Connection.Close();

            return response;
        }

        public ResponseDTO<List<ProjectDTO>> GetListClientProjects(RequestClientProjectDTO request)
        {
            database = DatabaseFactory.CreateDataBase(databaseType, "[CLIENT].[USP_GET_CLIENTPROYECTS]", request.IdCompany, request.IdClient, request.Project.IncludeDisabled, request.Project.Id);

            ResponseDTO<List<ProjectDTO>> response = mapperListCatalogDTO.MapperClientProject(database.DataReader);

            database.Connection.Close();

            return response;
        }

        public ResponseDTO<List<LocationDTO>> GetListProjectLocations(RequestProjectLocationsDTO request)
        {
            database = DatabaseFactory.CreateDataBase(databaseType, "[CLIENT].[USP_GET_PROYECTLOCATIONS]", request.IdProject, request.Location.IncludeDisabled, request.Location.Id);

            ResponseDTO<List<LocationDTO>> response = mapperListCatalogDTO.MapperProjectLocations(database.DataReader);

            database.Connection.Close();

            return response;
        }

        public ResponseDTO<List<InfoDTO>> GetListLocationSupervisors(RequestLocationSupervisorsDTO request)
        {
            database = DatabaseFactory.CreateDataBase(databaseType, "[CLIENT].[USP_GET_LOCATIONSUPERVISORS]",request.IdLocation,request.IdSupervisedRol);

            ResponseDTO<List<InfoDTO>> response = mapperListCatalogDTO.MapperUser(database.DataReader);

            database.Connection.Close();

            return response;
        }

        public ResponseDTO<List<InfoDTO>> GetListSupervisorsWorkers(UserDTO request)
        {
            database = DatabaseFactory.CreateDataBase(databaseType, "[CLIENT].[USP_GET_SUPERVISORWORKERS]", request.IdUser);

            ResponseDTO<List<InfoDTO>> response = mapperListCatalogDTO.MapperUser(database.DataReader);

            database.Connection.Close();

            return response;
        }


    }
}
