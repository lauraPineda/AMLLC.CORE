using AMLLC.CORE.DATA;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.DB;
using AMLLC.CORE.ENTITIES.User;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.DATAMANAGER
{
    public class UserDataManager
    {

        public ResponseDTO<UserDTO> AddUser(AddUserResponseDTO request)
        {
            Database database;
            DatabaseType databaseType = DatabaseType.SqlServer;
            database = DatabaseFactory.CreateDataBase(databaseType, "[USER].[USP_ADD_USER]", request.User.IdCompany,
                                                                                            request.User.UserName,
                                                                                            request.User.Password,
                                                                                            request.Info.Name,
                                                                                            request.Info.LastName,
                                                                                            request.Info.Telephone,
                                                                                            request.Info.HasTelephone);

            ResponseDTO<UserDTO> response = MapperUserDTO(database.DataReader);


            database.Connection.Close();

            return response;
        }

        public ResponseDTO<int> AddUserLocation(UserLocationRolDTO request)
        {
            Database database;
            DatabaseType databaseType = DatabaseType.SqlServer;
            database = DatabaseFactory.CreateDataBase(databaseType, "[USER].[USP_ADD_USERLOCATION]", request.IdRole,
                                                                                                    request.IdLocation,
                                                                                                    request.IdUser,
                                                                                                    request.IdUserSupervisor);
            int da = database.DataReader.RecordsAffected;

            ResponseDTO<int> response = new ResponseDTO<int>();
            response.Result = da;

            response.Success = true;

            database.Connection.Close();

            return response;
        }

        private ResponseDTO<UserDTO> MapperUserDTO(DbDataReader DbDataReader)
        {
            ResponseDTO<UserDTO> response = new ResponseDTO<UserDTO>();
            response.Result = new UserDTO();
            response.Success = true;

            if (DbDataReader.HasRows)
            {
                while (DbDataReader.Read())
                {
                    response.Result.IdUser = Convert.ToUInt32(DbDataReader["IdUser"]);
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong when trying to add the user.";
            }
            return response;
        }

    }
}
