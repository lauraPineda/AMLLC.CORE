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
    public class UserRequestRepository : IRepository<int, UserRequestDTO>
    {
        Database database;
        DatabaseType databaseType;
        public UserRequestRepository()
        {
            databaseType = DatabaseType.SqlServer;
        }
        public ResponseDTO<int> Add(RequestDTO<UserRequestDTO> entity)
        {
            ResponseDTO<int> response = new ResponseDTO<int>();
            response.Success = true;

            database = DatabaseFactory.CreateDataBase(databaseType, "[USER].[USP_ADD_USER]", entity.Signature.User.IdCompany,
                                                                                           entity.Signature.User.UserName,
                                                                                           entity.Signature.User.Password,
                                                                                           entity.Signature.Info.Name,
                                                                                           entity.Signature.Info.LastName,
                                                                                           entity.Signature.Info.Telephone,
                                                                                           entity.Signature.Info.HasTelephone);

            response=CommonMapper.MapperId(database.DataReader);


            database.Connection.Close();

            return response;
        }


        public ResponseDTO<IEnumerable<UserRequestDTO>> GetAll(RequestDTO<Boolean> IncludeDisabled)
        {
            ResponseDTO<IEnumerable<UserRequestDTO>> response = new ResponseDTO<IEnumerable<UserRequestDTO>>();
            ResponseDTO<List<UserRequestDTO>> responseList = Get(IncludeDisabled.Signature,null);

            if (responseList.Success)
                response.Result = responseList.Result.AsEnumerable();
            return response;
        }


        public ResponseDTO<UserRequestDTO> GetById(RequestDTO<int> entity)
        {
            ResponseDTO<UserRequestDTO> response = new ResponseDTO<UserRequestDTO>();
            ResponseDTO<List<UserRequestDTO>> responseList = Get(true, entity.Signature);

            if (responseList.Success)
                response.Result = responseList.Result.FirstOrDefault();
            return response;
        }

        public ResponseDTO<int> Update(RequestDTO<UserRequestDTO> entity)
        {
            database = DatabaseFactory.CreateDataBase(databaseType, "[USER].[USP_UPDATE_USER]", entity.Signature.User.IdUser,
                                                                                            entity.Signature.User.Enabled,
                                                                                            entity.Signature.User.Password,
                                                                                            entity.Signature.Info.Name,
                                                                                            entity.Signature.Info.LastName,
                                                                                            entity.Signature.Info.Telephone,
                                                                                            entity.Signature.Info.HasTelephone);
            ResponseDTO<int> response = CommonMapper.GetRecordsAffected(database.DataReader);

            database.Connection.Close();

            return response;
        }


        private ResponseDTO<List<UserRequestDTO>> Get(Boolean IncludeDisabled,int? UserId)
        {
             
            database = DatabaseFactory.CreateDataBase(databaseType, "[USER].[USP_GET_INFOUSER]", IncludeDisabled, UserId);
            ResponseDTO<List<UserRequestDTO>> response = UserRequestMapper.MapperLoginDTO(database.DataReader);
            database.Connection.Close();

            return response;
        }

    }
}
