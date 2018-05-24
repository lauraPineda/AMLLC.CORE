using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.Catalog;
using AMLLC.CORE.ENTITIES.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.BUSINESS.Company
{
    public class CompanyLogic
    {
        private IRepository<int, CatalogsDTO> _companyRequestRepository;

        public CompanyLogic(IRepository<int, CatalogsDTO> repository)
        {
            _companyRequestRepository = repository;
        }


        public ResponseDTO<CatalogsDTO> GetById(int request)
        {
            return _companyRequestRepository.GetById(request);
        }

        public ResponseDTO<IEnumerable<CatalogsDTO>> GetAll(Boolean request)
        {
            return _companyRequestRepository.GetAll(request);
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
