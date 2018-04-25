using AMLLC.CORE.DATA;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.DATAMANAGER
{
    public class ProjectDataManager
    {
        public ResponseDTO<List<ResponseCatalogDTO>> GetListClientProjects(RequestClientProjectDTO request)
        {
            Database database;
            DatabaseType databaseType = DatabaseType.SqlServer;
            MapperListCatalogDTO mapperListCatalogDTO = new MapperListCatalogDTO();

            database = DatabaseFactory.CreateDataBase(databaseType, "[CLIENT].[USP_GET_CLIENTPROYECTS]", request.IdCompany, request.IdClient,request.Project.IncludeDisabled, request.Project.Id);

            ResponseDTO<List<ResponseCatalogDTO>> response = mapperListCatalogDTO.Mapper(database.DataReader);

            database.Connection.Close();

            return response;
        }
    }
}
