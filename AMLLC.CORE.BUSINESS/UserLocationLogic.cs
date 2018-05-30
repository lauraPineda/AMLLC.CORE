using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.RequestFilter;
using AMLLC.CORE.ENTITIES.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.BUSINESS
{
    public class UserLocationLogic
    {
        private IRepository<int, UserLocationDTO, RequestSupervisorDTO> _userLocationRequestRepository;

        public UserLocationLogic(IRepository<int, UserLocationDTO, RequestSupervisorDTO> repository)
        {
            _userLocationRequestRepository = repository;
        }

        public ResponseDTO<IEnumerable<UserLocationDTO>> GetAll(RequestSupervisorDTO filter)
        {
            return _userLocationRequestRepository.GetAll(filter);
        }
    }
}
