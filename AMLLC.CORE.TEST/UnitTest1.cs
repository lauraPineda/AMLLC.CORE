using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES.DB;
using AMLLC.CORE.ENTITIES.User;
using AMLLC.CORE.ENTITIES;

namespace AMLLC.CORE.TEST
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            UserDataManager userDataManager = new UserDataManager();
            UserRequestDTO addUserResponseDTO = new UserRequestDTO();
            addUserResponseDTO.User = new UserDTO();
            addUserResponseDTO.User.IdCompany = 1;
            addUserResponseDTO.User.UserName = "Test1";
            addUserResponseDTO.User.Password = "AJfOisO9XyXSRvuD70K87qHqI / X5UkAzKUiIOH26 / bZT5PQF / dq / qTTu3qO / VZrIvA == ";
            addUserResponseDTO.Info = new InfoDTO();
            addUserResponseDTO.Info.Name = "Test";
            addUserResponseDTO.Info.LastName = "Test";
            addUserResponseDTO.Info.HasTelephone = false;
            addUserResponseDTO.Info.Telephone = null;

            ResponseDTO<UserDTO> response= new ResponseDTO<UserDTO>();

            response= userDataManager.AddUser(addUserResponseDTO);
        }
    }
}
