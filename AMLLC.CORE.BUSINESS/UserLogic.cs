using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.DB;
using AMLLC.CORE.ENTITIES.User;
using AMLLC.CORE.SHARED;
using System;
using System.Collections.Generic;

namespace AMLLC.CORE.BUSINESS.User
{
    public class UserLogic
    {
        private IRepository<int, UserRequestDTO> _userRequestRepository;


        public UserLogic(IRepository<int, UserRequestDTO> repository)
        {
            _userRequestRepository = repository;
        }

        public ResponseDTO<UserRequestDTO> GetById(int request)
        {
            return _userRequestRepository.GetById(request);
        }

        public ResponseDTO<IEnumerable<UserRequestDTO>> GetAll(Boolean request)
        {
            return _userRequestRepository.GetAll(request);
        }
        /// <summary>
        /// Se agrega información de usuarios nuevos
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Regresa id de usuario</returns>
        public ResponseDTO<int> Add(UserRequestDTO request)
        {
            request.User.Password = HashEncryption.Hash(request.User.Password);

            return _userRequestRepository.Add(request);
        }

        // <summary>
        /// Se actualiza la infomación de un usuario
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Regresa ibjeto de tipo UserDTO</returns>
        public ResponseDTO<int> Update(UserRequestDTO request)
        {

            request.User = request.User==null ? new UserDTO(request.Info.IdUser) : request.User;
            request.Info = request.Info==null ? new InfoDTO() : request.Info;

            request.User.Password=!string.IsNullOrEmpty(request.User.Password)? HashEncryption.Hash(request.User.Password):null;
            
            return _userRequestRepository.Update(request);
        }
    }
}
