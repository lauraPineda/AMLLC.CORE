using AMLLC.CORE.ENTITIES.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.RequestFilter;
using AMLLC.CORE.DATA;
using AMLLC.CORE.DATAMANAGER.Mapper;

namespace AMLLC.CORE.DATAMANAGER
{
    public class UserLocationRequestRepository : IRepository<int, UserLocationDTO, RequestSupervisorDTO>
    {
        Database database;
        DatabaseType databaseType;
        public UserLocationRequestRepository()
        {
            databaseType = DatabaseType.SqlServer;
        }

        public ResponseDTO<int> Add(UserLocationDTO entity)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO<IEnumerable<UserLocationDTO>> GetAll(RequestSupervisorDTO filter)
        {
            ResponseDTO<IEnumerable<UserLocationDTO>> response = new ResponseDTO<IEnumerable<UserLocationDTO>>();
            ResponseDTO<List<UserLocationDTO>> responseList = Get(filter.IncludeDisabled,filter.IdLocation,filter.SupervisedIdRole);

            if (responseList.Success)
                response.Result = responseList.Result.AsEnumerable();
            return response;
        }

        public ResponseDTO<UserLocationDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO<int> Update(UserLocationDTO entity)
        {
            throw new NotImplementedException();
        }

        private ResponseDTO<List<UserLocationDTO>> Get(bool IncludeDisabled, int? LocationId=null, int? IdSupervisedRol=null)
        {

            database = DatabaseFactory.CreateDataBase(databaseType, "[CLIENT].[USP_GET_SUPERVISORS]", IncludeDisabled, LocationId, IdSupervisedRol);
            ResponseDTO<List<UserLocationDTO>> response = UserRequestMapper.MapperInfoUserRoleDTO(database.DataReader);
            database.Connection.Close();

            return response;
        }
    }
}