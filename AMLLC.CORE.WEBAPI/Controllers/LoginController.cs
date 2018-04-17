using AMLLC.CORE.BUSINESS.Login;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.Login;
using System.Web.Http;

namespace AMLLC.CORE.WEBAPI.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public ResponseDTO<LoginDTO>GetLogin(LoginDTO request)
        {
            var response = new ResponseDTO<LoginDTO>();
            try
            {
                var loginLogic = LoginLogic.GetInstance();
                response = loginLogic.GetLogin(request);
            }
            catch (System.Data.SqlClient.SqlException exception)
            {
                response.Success = false;
                response.Message = exception.Message;
            }
            catch (System.Exception exception)
            {
                response.Success = false;
                response.Message = exception.Message;
            }

            return response;
        }
    }
}
