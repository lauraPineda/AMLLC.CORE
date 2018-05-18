using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AMLLC.CORE.BUSINESS.User;
using AMLLC.CORE.ENTITIES.User;
using AMLLC.CORE.ENTITIES;

namespace AMLLC.CORE.TEST
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void UpdateUser()
        {
            UserLogic updateUser = new UserLogic();
            RequestDTO<UserRequestDTO> userRequestDTO = new RequestDTO<UserRequestDTO>();
            userRequestDTO.Signature.User = new ENTITIES.DB.UserDTO(1);
            userRequestDTO.Signature.User.Password = "amllc";


            updateUser.UpdateUser(userRequestDTO);
        }
    }
}
