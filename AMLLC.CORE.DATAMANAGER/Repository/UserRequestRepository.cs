using AMLLC.CORE.DATA;
using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES.DB;
using AMLLC.CORE.ENTITIES.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.DATAMANAGER.Mapper;
using System.Data.Common;

namespace AMLLC.CORE.DATAMANAGER
{
    public class UserRequestRepository : IRepository<int, UserRequestDTO,bool>
    {
        Database database;
        DatabaseType databaseType;
        public UserRequestRepository()
        {
            databaseType = DatabaseType.SqlServer;
        }
        public ResponseDTO<int> Add(UserRequestDTO entity)
        {
            ResponseDTO<int> response = new ResponseDTO<int>();
            response.Success = true;

            database = DatabaseFactory.CreateDataBase(databaseType, "[USER].[USP_ADD_USER]", entity.User.IdCompany,
                                                                                           entity.User.UserName,
                                                                                           entity.User.Password,
                                                                                           entity.Info.Name,
                                                                                           entity.Info.LastName,
                                                                                           entity.Info.Telephone,
                                                                                           entity.Info.HasTelephone);

            response=CommonMapper.MapperId(database.DataReader);


            database.Connection.Close();

            return response;
        }


        public ResponseDTO<IEnumerable<UserRequestDTO>> GetAll(bool filter)
        {
            ResponseDTO<IEnumerable<UserRequestDTO>> response = new ResponseDTO<IEnumerable<UserRequestDTO>>();
            ResponseDTO<List<UserRequestDTO>> responseList = Get(filter);

            if (responseList.Success)
                response.Result = responseList.Result.AsEnumerable();
            return response;
        }


        public ResponseDTO<UserRequestDTO> GetById(int id)
        {
            ResponseDTO<UserRequestDTO> response = new ResponseDTO<UserRequestDTO>();
            ResponseDTO<List<UserRequestDTO>> responseList = Get(true, id);

            if (responseList.Success)
                response.Result = responseList.Result.FirstOrDefault();
            return response;
        }

        public ResponseDTO<int> Update(UserRequestDTO entity)
        {
            database = DatabaseFactory.CreateDataBase(databaseType, "[USER].[USP_UPDATE_USER]", entity.User.IdUser,
                                                                                            entity.User.Enabled,
                                                                                            entity.User.Password,
                                                                                            entity.Info.Name,
                                                                                            entity.Info.LastName,
                                                                                            entity.Info.Telephone,
                                                                                            entity.Info.HasTelephone);
            ResponseDTO<int> response = CommonMapper.GetRecordsAffected(database.DataReader);

            database.Connection.Close();

            return response;
        }


        private ResponseDTO<List<UserRequestDTO>> Get(bool IncludeDisabled,int? UserId=null)
        {
             
            database = DatabaseFactory.CreateDataBase(databaseType, "[USER].[USP_GET_INFOUSER]", IncludeDisabled, UserId);
            ResponseDTO<List<UserRequestDTO>> response = UserRequestMapper.MapperLoginDTO(database.DataReader);
            database.Connection.Close();

            return response;
        }

    }
}
