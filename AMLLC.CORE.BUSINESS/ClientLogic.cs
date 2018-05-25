using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.RequestFilter;
using System.Collections.Generic;

namespace AMLLC.CORE.BUSINESS
{
    public class ClientLogic
    {
        private IRepository<int, CatalogsDTO, CompanyFiltersDTO> _clientRequestRepository;

        public ClientLogic(IRepository<int, CatalogsDTO, CompanyFiltersDTO> repository)
        {
            _clientRequestRepository = repository;
        }


        public ResponseDTO<CatalogsDTO> GetById(int request)
        {
            return _clientRequestRepository.GetById(request);
        }

        public ResponseDTO<IEnumerable<CatalogsDTO>> GetAll(CompanyFiltersDTO filter)
        {
            return _clientRequestRepository.GetAll(filter);
        }
        /// <summary>
        /// Se agrega información de usuarios nuevos
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Regresa id de usuario</returns>
        public ResponseDTO<int> Add(CatalogsDTO request)
        {
            return _clientRequestRepository.Add(request);
        }

        // <summary>
        /// Se actualiza la infomación de un usuario
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Regresa ibjeto de tipo UserDTO</returns>
        public ResponseDTO<int> Update(CatalogsDTO request)
        {
            return _clientRequestRepository.Update(request);
        }

    }
}
