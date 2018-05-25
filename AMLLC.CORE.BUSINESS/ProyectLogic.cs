using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.BUSINESS
{
    public class ProyectLogic
    {
        private IRepository<int, CatalogsDTO, RequestProyectDTO> _proyectRequestRepository;

        public ProyectLogic(IRepository<int, CatalogsDTO, RequestProyectDTO> repository)
        {
            _proyectRequestRepository = repository;
        }

        public ResponseDTO<IEnumerable<CatalogsDTO>> GetAll(RequestProyectDTO filter)
        {
            return _proyectRequestRepository.GetAll(filter);
        }

    }
}
