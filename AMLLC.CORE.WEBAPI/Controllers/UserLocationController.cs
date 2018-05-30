using AMLLC.CORE.BUSINESS;
using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.RequestFilter;
using AMLLC.CORE.ENTITIES.User;
using AMLLC.CORE.SHARED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AMLLC.CORE.WEBAPI.Controllers
{
    [RoutePrefix("UserLocation")]
    public class UserLocationController : ApiController
    {
        #region "Global variables"
        UserLocationLogic userLocationLogic;
        #endregion

        #region "Constructor"
        public UserLocationController(IRepository<int, UserLocationDTO, RequestSupervisorDTO> repository)
        {
            userLocationLogic = new UserLocationLogic(repository);
        }
        #endregion

        /// <summary>
        /// Obtiene una colleción de los Usuarios existentes
        /// </summary>
        /// <param name="request">Obtener solo usuario activos</param>
        /// <returns>Lista de usuarios obtenidos</returns>
        [HttpPost]
        [Route("GetAll")]
        public ResponseDTO<IEnumerable<UserLocationDTO>> GetAll(RequestDTO<RequestSupervisorDTO> request)
        {
            var response = new ResponseDTO<IEnumerable<UserLocationDTO>>();
            try
            {
                response = userLocationLogic.GetAll(request.Signature);
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
