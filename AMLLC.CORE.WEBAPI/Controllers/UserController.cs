
using AMLLC.CORE.BUSINESS.User;
using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.DB;
using AMLLC.CORE.ENTITIES.User;
using AMLLC.CORE.SHARED;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AMLLC.CORE.WEBAPI.Controllers
{
    [RoutePrefix("User")]
    public class UserController : ApiController
    {
        #region "Global variables"
        UserLogic userLogic;
        #endregion

        #region "Constructor"
        public UserController(IRepository<int, UserRequestDTO,bool> repository)
        {
            userLogic = new UserLogic(repository);
        }
        #endregion

        /// <summary>
        /// Obtene la informacion de un usuario por su numero de IdUser
        /// </summary>
        /// <param name="request">Id de usuario a obtener</param>
        /// <returns>Información del usuario solicitado</returns>
        [HttpPost]
        [Route("GetById")]
        public ResponseDTO<UserRequestDTO> GetbyId(RequestDTO<int> request)
        {
            var response = new ResponseDTO<UserRequestDTO>();
            try
            {
                response= userLogic.GetById(request.Signature);
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

        /// <summary>
        /// Obtiene una colleción de los Usuarios existentes
        /// </summary>
        /// <param name="request">Obtener solo usuario activos</param>
        /// <returns>Lista de usuarios obtenidos</returns>
        [HttpPost]
        [Route("GetAll")]
        public ResponseDTO<IEnumerable<UserRequestDTO>> GetAll(RequestDTO<Boolean> request)
        {
            var response = new ResponseDTO<IEnumerable<UserRequestDTO>>();
            try
            {
                response = userLogic.GetAll(request.Signature);
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

        /// <summary>
        /// Agrega un nuevo usuario y su información
        /// </summary>
        /// <param name="request">UserRequestDTO</param>
        /// <returns>IdUser</returns>
        [HttpPost]
        [Route("Add")]
        public ResponseDTO<int> AddUser(RequestDTO<UserRequestDTO> request)
        {
            var response = new ResponseDTO<int>();
            try
            {
                response = userLogic.Add(request.Signature);
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

        /// <summary>
        /// Actualiza la información de un usuario
        /// </summary>
        /// <param name="request">UserRequestDTO</param>
        /// <returns>Número de registros afectados</returns>
        [HttpPost]
        [Route("Update")]
        public ResponseDTO<int> UpdateUser(RequestDTO<UserRequestDTO> request)
        {
            var response = new ResponseDTO<int>();
            try
            {
                response = userLogic.Update(request.Signature);
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
