using AMLLC.CORE.BUSINESS;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.SHARED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AMLLC.CORE.WEBAPI.Controllers
{
    [RoutePrefix("Supervisor/Catalog")]
    public class CatalogController : ApiController
    {
        [HttpPost]
        [Route("GetCompany")]
        public ResponseDTO<List<ResponseCatalogDTO>> ListCompanies(RequestDTO<RequestCatalogDTO> request)
        {
            var response = new ResponseDTO<List<ResponseCatalogDTO>>();
            try
            {
                CatalogLogic catalogLogic = new CatalogLogic();
                response = catalogLogic.GetListCatalog(request.Signature, CatalogEnum.Catalogs.Company);
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
