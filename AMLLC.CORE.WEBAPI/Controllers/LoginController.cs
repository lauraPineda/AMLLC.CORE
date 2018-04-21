using AMLLC.CORE.BUSINESS.Login;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.DB;
using AMLLC.CORE.ENTITIES.Login;
using AMLLC.CORE.SHARED;
using System.Web.Http;

namespace AMLLC.CORE.WEBAPI.Controllers
{
    [RoutePrefix("Supervisor/Login")]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("Get")]
        public ResponseDTO<LoginResponseDTO>GetLogin(RequestDTO<UserDTO> request)
        {
            var response = new ResponseDTO<LoginResponseDTO>();
            try
            {
                response = LoginLogic.GetInstance.GetLogin(request);
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
