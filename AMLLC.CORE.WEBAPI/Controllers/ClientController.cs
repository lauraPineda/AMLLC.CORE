using AMLLC.CORE.BUSINESS.Client;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.Catalog;
using AMLLC.CORE.SHARED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AMLLC.CORE.WEBAPI.Controllers
{
    [RoutePrefix("Supervisor/Client")]
    public class ClientController : ApiController
    {
        [HttpPost]
        [Route("GetProjects")]
        public ResponseDTO<List<ResponseCatalogDTO>> ListCompanyClients(RequestDTO<RequestClientProjectDTO> request)
        {
            var response = new ResponseDTO<List<ResponseCatalogDTO>>();
            try
            {
                ClientLogic CompanyLogic = new ClientLogic();
                response = CompanyLogic.GetListCatalog(request.Signature);
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
