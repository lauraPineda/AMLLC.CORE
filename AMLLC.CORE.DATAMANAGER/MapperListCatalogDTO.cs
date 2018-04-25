using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.Catalog;
using AMLLC.CORE.ENTITIES.DB;
using AMLLC.CORE.SHARED;
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
                        Id = Helper.GetInt32(DbDataReader, "Id"),
                        Name = Helper.GetString(DbDataReader, "Name"),
                        Description = Helper.GetString(DbDataReader, "Description"),
                        Enabled = Helper.GetBoolean(DbDataReader, "Enabled")
                    });
                }

            }
            return response;
        }

        public ResponseDTO<List<ProjectDTO>> MapperClientProject(DbDataReader DbDataReader)
        {
            ResponseDTO<List<ProjectDTO>> response = new ResponseDTO<List<ProjectDTO>>();
            response.Result = new List<ProjectDTO>();
            response.Success = true;

            if (DbDataReader.HasRows)
            {
                while (DbDataReader.Read())
                {
                    response.Result.Add(new ProjectDTO
                    {
                        IdProject = Helper.GetInt32(DbDataReader, "Id"),
                        Name = Helper.GetString(DbDataReader, "Name"),
                        Description = Helper.GetString(DbDataReader, "Description"),
                        StartDate = Helper.GetNullDateTime(DbDataReader, "StartDate"),
                        EndDate = Helper.GetNullDateTime(DbDataReader, "EndDate"),
                        Enabled = Helper.GetBoolean(DbDataReader, "Enabled")
                    });
                }

            }
            return response;
        }


        public ResponseDTO<List<LocationDTO>> MapperProjectLocations(DbDataReader DbDataReader)
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
            return response;
        }
    }
}
