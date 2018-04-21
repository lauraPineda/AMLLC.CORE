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
        public ResponseDTO<UserDTO> AddUser(RequestDTO<AddUserResponseDTO> request)
        {
            var response = new ResponseDTO<UserDTO>();
            try
            {
                response = AddUserLogic.GetInstance.AddUser(request.Signature);
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
