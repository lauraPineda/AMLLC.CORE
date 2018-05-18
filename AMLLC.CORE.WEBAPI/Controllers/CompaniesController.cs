using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AMLLC.CORE.WEBAPI.Controllers
{
    [RoutePrefix("Companies")]
    public class CompaniesController : ApiController
    {
        private IRepository<int, ResponseCatalogDTO> _productRepository;

        public CompaniesController(IRepository<int, ResponseCatalogDTO> repository)
        {
            _productRepository = repository;
        }
    //    [Route("GetAll")]
    //    public IEnumerable<ResponseCatalogDTO> GetAll()
    //    {
    //        //return _productRepository.GetAll();
    //    }
    }
}
