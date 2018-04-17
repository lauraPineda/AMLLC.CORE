using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.Login;

namespace AMLLC.CORE.TEST
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            ResponseDTO<ENTITIES.Login.LoginDTO> response = new ResponseDTO<ENTITIES.Login.LoginDTO>();

            LoginDataManger loginDataManger = new LoginDataManger();

            LoginDTO loginDTO = new LoginDTO();
            loginDTO.User = new ENTITIES.DB.UserDTO();
            loginDTO.User.UserName = "JORGE";
            response=loginDataManger.LoginSupervisor(loginDTO);

        }
    }
}
