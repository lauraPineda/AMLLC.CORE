using AMLLC.CORE.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.DATAMANAGER
{
    public class MapperListCatalogDTO
    {
        public ResponseDTO<List<ResponseCatalogDTO>> Mapper(DbDataReader DbDataReader)
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
