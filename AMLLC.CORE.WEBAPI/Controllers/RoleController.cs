using AMLLC.CORE.BUSINESS;
using AMLLC.CORE.DATAMANAGER;
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
    [RoutePrefix("Role")]
    public class RoleController : ApiController
    {
        #region "Global variables"
        RoleLogic roleLogic;
        #endregion

        #region "Constructor"
        public RoleController(IRepository<int, CatalogsDTO, RequestCatalogDTO> repository)
        {
            roleLogic = new RoleLogic(repository);
        }
        #endregion


        [HttpPost]
        [Route("GetAll")]
        public ResponseDTO<IEnumerable<CatalogsDTO>> GetAll(RequestDTO<RequestCatalogDTO> request)
        {
            var response = new ResponseDTO<IEnumerable<CatalogsDTO>>();
            try
            {
                response = roleLogic.GetAll(request.Signature);
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
