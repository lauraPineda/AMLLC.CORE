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
    public class RoleLogic
    {
        private IRepository<int, CatalogsDTO, RequestCatalogDTO> _companyRequestRepository;

        public RoleLogic(IRepository<int, CatalogsDTO, RequestCatalogDTO> repository)
        {
            _companyRequestRepository = repository;
        }


        public ResponseDTO<CatalogsDTO> GetById(int request)
        {
            return _companyRequestRepository.GetById(request);
        }

        public ResponseDTO<IEnumerable<CatalogsDTO>> GetAll(RequestCatalogDTO filter)
        {
            return _companyRequestRepository.GetAll(filter);
        }
        /// <summary>
        /// Se agrega información de usuarios nuevos
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Regresa id de usuario</returns>
        public ResponseDTO<int> Add(CatalogsDTO request)
        {
            return _companyRequestRepository.Add(request);
        }

        // <summary>
        /// Se actualiza la infomación de un usuario
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Regresa ibjeto de tipo UserDTO</returns>
        public ResponseDTO<int> Update(CatalogsDTO request)
        {
            return _companyRequestRepository.Update(request);
        }
    }
}
