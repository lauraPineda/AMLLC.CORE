using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.Catalog;
using AMLLC.CORE.ENTITIES.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.BUSINESS
{
    public class LocationLogic
    {
        private IRepository<int, LocationDTO, RequestLocationsDTO> _locationRequestRepository;

        public LocationLogic(IRepository<int, LocationDTO, RequestLocationsDTO> repository)
        {
            _locationRequestRepository = repository;
        }

        public ResponseDTO<IEnumerable<LocationDTO>> GetAll(RequestLocationsDTO filter)
        {
            return _locationRequestRepository.GetAll(filter);
        }
    }
}
