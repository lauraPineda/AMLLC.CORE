using AMLLC.CORE.DATA;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.DB;
using AMLLC.CORE.ENTITIES.Login;
using AMLLC.CORE.SHARED;
using System;
using System.Data.Common;

namespace AMLLC.CORE.DATAMANAGER
{
   public class LoginDataManger
    {

        /// <summary>
        /// Obtiene contraseña del usuario solicitado
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ResponseDTO<LoginResponseDTO> LoginSupervisor(UserDTO request)
        {  
            Database database;
            DatabaseType databaseType = DatabaseType.SqlServer;
            database = DatabaseFactory.CreateDataBase(databaseType, "[USER].[USP_GET_INFOUSER_SUPERVISOR]", request.UserName.ToString());

            ResponseDTO<LoginResponseDTO> response = MapperLoginDTO(database.DataReader);

            database.Connection.Close();
            
            return response;
        }

        /// <summary>
        /// Mapea los datos del usuario obtenidos de la base de datos
        /// </summary>
        /// <param name="DbDataReader">Datos obtenidos de la consulta a base de datos</param>
        /// <returns>Objeto mapeado con la información obtenida del usuario </returns>
        private ResponseDTO<LoginResponseDTO> MapperLoginDTO(DbDataReader DbDataReader)
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
                    response.Result.User.Password = Helper.GetString(DbDataReader,"Password");

                    response.Result.Role.IdRole =Helper.GetUInt16(DbDataReader,"IdRole");
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
