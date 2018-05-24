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
        public static ResponseDTO<List<LoginResponseDTO>> MapperLoginDTO(DbDataReader DbDataReader)
        {
            ResponseDTO<List<LoginResponseDTO>> response = new ResponseDTO<List<LoginResponseDTO>>();
            response.Result = new List<LoginResponseDTO>();
            response.Success = true;

            if (DbDataReader.HasRows)
            {
                while (DbDataReader.Read())
                {
                    response.Result.Add(new LoginResponseDTO
                    {
                        User = new UserDTO
                        {
                            IdUser = Helper.GetUInt32(DbDataReader, "IdUser"),
                            UserName = Helper.GetString(DbDataReader, "UserName"),
                            Password = Helper.GetString(DbDataReader, "Password")
                        },
                        Role = new RoleDTO
                        {
                            IdRole = Helper.GetUInt16(DbDataReader, "IdRole"),
                            Name = Helper.GetString(DbDataReader, "Rol")
                        }
                    });
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
