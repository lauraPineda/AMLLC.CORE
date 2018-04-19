using AMLLC.CORE.DATA;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.Login;
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
        public ResponseDTO<LoginDTO> LoginSupervisor(ENTITIES.Login.LoginDTO request)
        {
            ResponseDTO<LoginDTO> response = new ResponseDTO<ENTITIES.Login.LoginDTO>();
            
            Database database;
            DatabaseType databaseType = DatabaseType.SqlServer;
            database = DatabaseFactory.CreateDataBase(databaseType, "[USER].[SP_GE_INFOUSER_SUPERVISOR]", request.User.UserName.ToString());

            response = MapperLoginDTO(database.DataReader);

            database.Connection.Close();
            
            return response;
        }

        /// <summary>
        /// Mapea los datos del usuario obtenidos de la base de datos
        /// </summary>
        /// <param name="DbDataReader">Datos obtenidos de la consulta a base de datos</param>
        /// <returns>Objeto mapeado con la información obtenida del usuario </returns>
        private ResponseDTO<LoginDTO> MapperLoginDTO(DbDataReader DbDataReader)
        {
            ResponseDTO<LoginDTO> response = new ResponseDTO<LoginDTO>();
            response.Result = new LoginDTO();
            response.Result.User = new ENTITIES.DB.UserDTO();
            response.Result.Info = new ENTITIES.DB.InfoDTO();
            response.Result.Role = new ENTITIES.DB.RoleDTO();
            response.Success = true;

            if (DbDataReader.HasRows)
            {
                while (DbDataReader.Read())
                {
                    response.Result.User.IdUser = Convert.ToUInt32(DbDataReader["IdUser"]);
                    response.Result.User.UserName = Convert.ToString(DbDataReader["UserName"]);
                    response.Result.User.Password = Convert.ToString(DbDataReader["Password"]);

                    response.Result.Info.Name = Convert.ToString(DbDataReader["Name"]);
                    response.Result.Info.LastName = Convert.ToString(DbDataReader["LastName"]);

                    response.Result.Role.IdRole = (ushort)Convert.ToInt16(DbDataReader["IdRole"]);
                    response.Result.Role.Name = Convert.ToString(DbDataReader["Rol"]);
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Username or Password is incorrect.";

            }
            return response;
        }
    }
}
