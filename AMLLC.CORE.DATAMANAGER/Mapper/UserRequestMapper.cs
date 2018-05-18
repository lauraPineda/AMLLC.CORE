using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.DB;
using AMLLC.CORE.ENTITIES.User;
using AMLLC.CORE.SHARED;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.DATAMANAGER.Mapper
{
    public class UserRequestMapper
    {
        public static ResponseDTO<List<UserRequestDTO>> MapperLoginDTO(DbDataReader DbDataReader)
        {
            ResponseDTO<List<UserRequestDTO>> response = new ResponseDTO<List<UserRequestDTO>>();
            response.Result= new List<UserRequestDTO>();
            response.Success = true;

            if (DbDataReader.HasRows)
            {
                while (DbDataReader.Read())
                {
                    response.Result.Add(new UserRequestDTO
                    {
                        User = new UserDTO
                        {
                            IdUser = Helper.GetUInt32(DbDataReader, "IdUser"),
                            UserName = Helper.GetString(DbDataReader, "UserName"),
                            Enabled = Helper.GetBoolean(DbDataReader, "Enabled")
                        },
                        Info = new InfoDTO
                        {

                            Name = Helper.GetString(DbDataReader, "Name"),
                            LastName = Helper.GetString(DbDataReader, "LastName"),
                            Telephone = Helper.GetString(DbDataReader, "Telephone"),
                            HasTelephone = Helper.GetBoolean(DbDataReader, "HasTelephone"),
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
