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

        public ResponseDTO<UserDTO> AddUser(UserRequestDTO request)
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

        public ResponseDTO<int> UpdateUser(UserRequestDTO request)
        {
            Database database;
            DatabaseType databaseType = DatabaseType.SqlServer;
            database = DatabaseFactory.CreateDataBase(databaseType, "[USER].[USP_UPDATE_USER]", request.User.IdUser,
                                                                                            request.User.Enabled,
                                                                                            request.User.Password,
                                                                                            request.Info.Name ?? null,
                                                                                            request.Info.LastName ?? null,
                                                                                            request.Info.Telephone ?? null,
                                                                                            request.Info.HasTelephone);
            ResponseDTO<int> response = GetRecordsAffected(database.DataReader);

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
            ResponseDTO<int> response=GetRecordsAffected(database.DataReader);

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

        private ResponseDTO<int> GetRecordsAffected(DbDataReader DbDataReader)
        {
            int recordsAffectes = DbDataReader.RecordsAffected;

            ResponseDTO<int> response = new ResponseDTO<int>();

            response.Result = recordsAffectes;

            response.Success = response.Result>0?true:false;
            
            return response;
        }

    }
}
