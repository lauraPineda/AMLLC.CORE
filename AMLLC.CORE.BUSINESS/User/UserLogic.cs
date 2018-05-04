using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.DB;
using AMLLC.CORE.ENTITIES.User;
using AMLLC.CORE.SHARED;
using System;

namespace AMLLC.CORE.BUSINESS.User
{
    public class UserLogic
    {
        UserDataManager userDataManager;

        public UserLogic()
        {
            userDataManager = new UserDataManager();
        }


        /// <summary>
        /// Se agrega información de usuarios nuevos
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Regresa ibjeto de tipo UserDTO</returns>
        public ResponseDTO<UserDTO> AddUser(UserRequestDTO request)
        {
            request.User.Password = HashEncryption.Hash(request.User.Password);

            ResponseDTO<UserDTO> response = userDataManager.AddUser(request);
            
            return response;
        }

        // <summary>
        /// Se actualiza la infomación de un usuario
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Regresa ibjeto de tipo UserDTO</returns>
        public ResponseDTO<int> UpdateUser(UserRequestDTO request)
        {

            request.User = request.User==null ? new UserDTO(request.Info.IdUser) : request.User;
            request.Info = request.Info==null ? new InfoDTO() : request.Info;

            request.User.Password=!string.IsNullOrEmpty(request.User.Password)? HashEncryption.Hash(request.User.Password):null;

            ResponseDTO<int> response = userDataManager.UpdateUser(request);

            return response;
        }
    }
}
