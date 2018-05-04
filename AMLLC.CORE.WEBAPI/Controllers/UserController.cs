 
using AMLLC.CORE.BUSINESS.User;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.DB;
using AMLLC.CORE.ENTITIES.User;
using AMLLC.CORE.SHARED;
using System.Web.Http;

namespace AMLLC.CORE.WEBAPI.Controllers
{
    [RoutePrefix("Supervisor/User")]
    public class UserController : ApiController
    {

        [HttpPost]
        [Route("Add")]
        public ResponseDTO<UserDTO> AddUser(RequestDTO<UserRequestDTO> request)
        {
            var response = new ResponseDTO<UserDTO>();
            try
            {
                UserLogic userLogic = new UserLogic();
                response = userLogic.AddUser(request.Signature);
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

        [HttpPost]
        [Route("Update")]
        public ResponseDTO<int> UpdateUser(RequestDTO<UserRequestDTO> request)
        {
            var response = new ResponseDTO<int>();
            try
            {
                UserLogic userLogic = new UserLogic();
                response = userLogic.UpdateUser(request.Signature);
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

        [HttpPost]
        [Route("AddLocation")]
        public ResponseDTO<int> AddUserLocation(RequestDTO<UserLocationRolDTO> request)
        {
            var response = new ResponseDTO<int>();
            try
            {
                response = UserLocationLogic.GetInstance.AddUserLocation(request.Signature);
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
