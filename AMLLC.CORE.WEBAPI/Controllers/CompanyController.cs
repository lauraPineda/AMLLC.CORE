﻿using AMLLC.CORE.BUSINESS;
using AMLLC.CORE.BUSINESS.Company;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.Catalog;
using AMLLC.CORE.SHARED;
using System.Collections.Generic;
using System.Web.Http;

namespace AMLLC.CORE.WEBAPI.Controllers
{
    [RoutePrefix("Supervisor/Company")]
    public class CompanyController : ApiController
    {
        [HttpPost]
        [Route("GetClients")]
        public ResponseDTO<List<ResponseCatalogDTO>> ListCompanyClients(RequestDTO<RequestCompanyClientsDTO> request)
        {
            var response = new ResponseDTO<List<ResponseCatalogDTO>>();
            try
            {
                CompanyLogic CompanyLogic = new CompanyLogic();
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