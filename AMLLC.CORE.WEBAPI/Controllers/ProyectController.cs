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
    [RoutePrefix("Proyect")]
    public class ProyectController : ApiController
    {
        #region "Global variables"
        ProyectLogic proyectLogic;
        #endregion

        #region "Constructor"
        public ProyectController(IRepository<int, CatalogsDTO, RequestProyectDTO> repository)
        {
            proyectLogic = new ProyectLogic(repository);
        }
        #endregion

        [HttpPost]
        [Route("GetAll")]
        public ResponseDTO<IEnumerable<CatalogsDTO>> GetAll(RequestDTO<RequestProyectDTO> request)
        {
            var response = new ResponseDTO<IEnumerable<CatalogsDTO>>();
            try
            {
                response = proyectLogic.GetAll(request.Signature);
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
