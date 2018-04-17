using AMLLC.CORE.DATA;
using AMLLC.CORE.ENTITIES;
using System;

namespace AMLLC.CORE.DATAMANAGER
{
   public class LoginDataManger
    {
        public ResponseDTO<ENTITIES.Login.LoginDTO> LoginSupervisor(ENTITIES.Login.LoginDTO request)
        {
            ResponseDTO<ENTITIES.Login.LoginDTO> response = new ResponseDTO<ENTITIES.Login.LoginDTO>();
            response.Result = new ENTITIES.Login.LoginDTO();
            response.Result.User = new ENTITIES.DB.UserDTO();
            Database database;
            DatabaseType databaseType = DatabaseType.SqlServer;
            database = DatabaseFactory.CreateDataBase(databaseType, "[USER].[SP_GET_LOGIN]", request.User.UserName.ToString());

            if (database.DataReader.HasRows)
            {

                while (database.DataReader.Read())
                {

                    response.Result.User.Password = Convert.ToString(database.DataReader["Password"]);
                }
            }
            database.Connection.Close();

            response.Success = true;
            response.Message = "Ok";

            return response;
        }
    }
}
