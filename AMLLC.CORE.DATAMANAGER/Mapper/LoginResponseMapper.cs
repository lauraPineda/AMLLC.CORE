using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.Login;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMLLC.CORE.ENTITIES.DB;
using AMLLC.CORE.SHARED;

namespace AMLLC.CORE.DATAMANAGER.Mapper
{
    public class LoginResponseMapper
    {
        /// <summary>
        /// Mapea los datos del usuario obtenidos de la base de datos
        /// </summary>
        /// <param name="DbDataReader">Datos obtenidos de la consulta a base de datos</param>
        /// <returns>Objeto mapeado con la información obtenida del usuario </returns>
        public static ResponseDTO<LoginResponseDTO> MapperLoginDTO(DbDataReader DbDataReader)
        {
            ResponseDTO<LoginResponseDTO> response = new ResponseDTO<LoginResponseDTO>();
            response.Result = new LoginResponseDTO();
            response.Result.User = new UserDTO();
            response.Result.Role = new RoleDTO();
            response.Success = true;

            if (DbDataReader.HasRows)
            {
                while (DbDataReader.Read())
                {
                    response.Result.User.IdUser = Helper.GetUInt32(DbDataReader, "IdUser");
                    response.Result.User.UserName = Helper.GetString(DbDataReader, "UserName");
                    response.Result.User.Password = Helper.GetString(DbDataReader, "Password");

                    response.Result.Role.IdRole = Helper.GetUInt16(DbDataReader, "IdRole");
                    response.Result.Role.Name = Helper.GetString(DbDataReader, "Rol");
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Username or Password incorrect.";

            }
            return response;

        }
    }
}
