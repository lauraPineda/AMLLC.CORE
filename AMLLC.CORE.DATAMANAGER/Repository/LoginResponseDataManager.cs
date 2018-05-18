using AMLLC.CORE.DATA;
using AMLLC.CORE.DATAMANAGER.Mapper;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.DB;
using AMLLC.CORE.ENTITIES.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.DATAMANAGER
{
    public class LoginResponseDataManager
    {
        Database database;
        DatabaseType databaseType;

        public LoginResponseDataManager()
        {
            databaseType = DatabaseType.SqlServer;
        }

        public ResponseDTO<LoginResponseDTO> GetByUser(UserDTO entity)
        {
            database = DatabaseFactory.CreateDataBase(databaseType, "[USER].[USP_GET_LOGININFO_SUPERVISOR]", entity.UserName.ToString());

            ResponseDTO<LoginResponseDTO> response = LoginResponseMapper.MapperLoginDTO(database.DataReader);

            database.Connection.Close();

            return response;
        }
    }
}
