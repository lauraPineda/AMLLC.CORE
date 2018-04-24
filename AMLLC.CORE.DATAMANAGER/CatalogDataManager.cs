using AMLLC.CORE.DATA;
using AMLLC.CORE.ENTITIES;
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
        public ResponseDTO<List<ResponseCatalogDTO>> GetListCatalog(RequestCatalogDTO request, string uspName)
        {
            Database database;
            DatabaseType databaseType = DatabaseType.SqlServer;

            database = DatabaseFactory.CreateDataBase(databaseType, uspName, request.IncludeDisabled, request.Id);

            ResponseDTO<List<ResponseCatalogDTO>> response = MapperListCatalogDTO(database.DataReader);

            database.Connection.Close();

            return response;
        }


        private ResponseDTO<List<ResponseCatalogDTO>> MapperListCatalogDTO(DbDataReader DbDataReader)
        {
            ResponseDTO<List<ResponseCatalogDTO>> response = new ResponseDTO<List<ResponseCatalogDTO>>();
            response.Result = new List<ResponseCatalogDTO>();
            response.Success = true;

            if (DbDataReader.HasRows)
            {
                while (DbDataReader.Read())
                {
                    response.Result.Add(new ResponseCatalogDTO
                    {
                        Id = Convert.ToInt16(DbDataReader["Id"]),
                        Name = Convert.ToString(DbDataReader["Name"]),
                        Description = Convert.ToString(DbDataReader["Description"]),
                        Enabled = Convert.ToBoolean(DbDataReader["Enabled"])
                    });
                }

            }
            return response;
        }
    }
}
