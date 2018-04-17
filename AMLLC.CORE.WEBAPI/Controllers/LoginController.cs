using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.Login;
using System.Web.Http;

namespace AMLLC.CORE.WEBAPI.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public ResponseDTO<LoginDTO> User(LoginDTO request)
        {
            var response = new ResponseDTO<LoginDTO>();
            return response;
        }
    }
}
