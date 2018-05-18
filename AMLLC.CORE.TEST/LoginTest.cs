using Microsoft.VisualStudio.TestTools.UnitTesting;
using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.Login;
using AMLLC.CORE.ENTITIES.DB;
using AMLLC.CORE.BUSINESS.Login;

namespace AMLLC.CORE.TEST
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            LoginLogic loginLogic = new LoginLogic();
            ResponseDTO<LoginResponseDTO> response = new ResponseDTO<LoginResponseDTO>();



            var User = new UserDTO()
            {
                UserName = "amllc",
                Password="amllc2"
            };

            response = loginLogic.ValidateUser(User);

        }
    }
}
