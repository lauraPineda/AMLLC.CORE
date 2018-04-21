using Microsoft.VisualStudio.TestTools.UnitTesting;
using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.Login;
using AMLLC.CORE.ENTITIES.DB;

namespace AMLLC.CORE.TEST
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ResponseDTO<LoginResponseDTO> response = new ResponseDTO<LoginResponseDTO>();

            LoginDataManger loginDataManger = new LoginDataManger();

            var User = new UserDTO()
            {
                UserName = "JORGE"
            };

            response = loginDataManger.LoginSupervisor(User);

        }
    }
}
