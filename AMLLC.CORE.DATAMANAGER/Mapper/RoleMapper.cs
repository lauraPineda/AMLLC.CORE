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
    public class RoleMapper
    {
        public static ResponseDTO<RoleDTO> MapperRoleDTO(DbDataReader DbDataReader)
        {
            ResponseDTO<RoleDTO> response = new ResponseDTO<RoleDTO>();
            response.Result = new RoleDTO();
            response.Success = true;
            if (DbDataReader.HasRows)
            {
                while (DbDataReader.Read())
                {

                    response.Result.IdRole = Helper.GetUInt16(DbDataReader, "IdRole");
                    response.Result.Name = Helper.GetString(DbDataReader, "Rol");
                }
            }
            else
            {
                response.Success = false;
                response.Message = "There was an error loading the rol.";

            }
            return response;
        }
    }
}
