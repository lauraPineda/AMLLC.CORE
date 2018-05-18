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

        public ResponseDTO<UserRequestDTO> GetById(RequestDTO<int> request)
        {
            return _userRequestRepository.GetById(request);
        }

        public ResponseDTO<IEnumerable<UserRequestDTO>> GetAll(RequestDTO<Boolean> request)
        {
            return _userRequestRepository.GetAll(request);
        }
        /// <summary>
        /// Se agrega información de usuarios nuevos
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Regresa id de usuario</returns>
        public ResponseDTO<int> AddUser(RequestDTO<UserRequestDTO> request)
        {
            request.Signature.User.Password = HashEncryption.Hash(request.Signature.User.Password);

            return _userRequestRepository.Add(request);
        }

        // <summary>
        /// Se actualiza la infomación de un usuario
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Regresa ibjeto de tipo UserDTO</returns>
        public ResponseDTO<int> UpdateUser(RequestDTO<UserRequestDTO> request)
        {

            request.Signature.User = request.Signature.User==null ? new UserDTO(request.Signature.Info.IdUser) : request.Signature.User;
            request.Signature.Info = request.Signature.Info==null ? new InfoDTO() : request.Signature.Info;

            request.Signature.User.Password=!string.IsNullOrEmpty(request.Signature.User.Password)? HashEncryption.Hash(request.Signature.User.Password):null;
            
            return _userRequestRepository.Update(request);
        }
    }
}
