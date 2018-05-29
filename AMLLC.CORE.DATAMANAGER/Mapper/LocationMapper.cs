using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.DB;
using AMLLC.CORE.SHARED;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.DATAMANAGER.Mapper
{
    public class LocationMapper
    {

        public static ResponseDTO<List<LocationDTO>> MapperLocationDTO(DbDataReader DbDataReader)
        {
            ResponseDTO<List<LocationDTO>> response = new ResponseDTO<List<LocationDTO>>();
            response.Result = new List<LocationDTO>();
            response.Success = true;

            if (DbDataReader.HasRows)
            {
                while (DbDataReader.Read())
                {
                    response.Result.Add(new LocationDTO
                    {
                        IdProject = Helper.GetInt32(DbDataReader, "Id"),
                        Description = Helper.GetString(DbDataReader, "Description"),
                        Longitude = Helper.GetDouble(DbDataReader, "Longitude"),
                        Latitude = Helper.GetDouble(DbDataReader, "Latitude"),
                        Enabled = Helper.GetBoolean(DbDataReader, "Enabled")
                    });
                }

            }
            else
            {
                response.Success = false;
                response.Message = "There was an error loading the location.";

            }
            return response;
        }
    }
}
