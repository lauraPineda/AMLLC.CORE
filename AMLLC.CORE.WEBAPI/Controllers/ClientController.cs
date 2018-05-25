using AMLLC.CORE.BUSINESS;
using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.Catalog;
using AMLLC.CORE.ENTITIES.RequestFilter;
using AMLLC.CORE.SHARED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AMLLC.CORE.WEBAPI.Controllers
{
    [RoutePrefix("Client")]
    public class ClientController : ApiController
    {
        #region "Global variables"
        ClientLogic clientLogic;
        #endregion

        #region "Constructor"
        public ClientController(IRepository<int, CatalogsDTO, CompanyFiltersDTO> repository)
        {
            clientLogic = new ClientLogic(repository);
        }
        #endregion

        [HttpPost]
        [Route("GetAll")]
        public ResponseDTO<IEnumerable<CatalogsDTO>> GetAll(RequestDTO<CompanyFiltersDTO> request)
        {
            var response = new ResponseDTO<IEnumerable<CatalogsDTO>>();
            try
            {
                response = clientLogic.GetAll(request.Signature);
            }
            catch (System.Data.SqlClient.SqlException exception)
            {
                response.Success = false;
                response.Message = exception.Message;
                ExceptionHandler.Instance.WriteExceptionLog(exception);
            }
            catch (System.Exception exception)
            {
                response.Success = false;
                response.Message = exception.Message;
                ExceptionHandler.Instance.WriteExceptionLog(exception);
            }
            return response;
        }
    }
}
