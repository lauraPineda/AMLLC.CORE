using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.DB;
using AMLLC.CORE.ENTITIES.Login;
using AMLLC.CORE.SHARED;
using System.Collections.Generic;
using System.Linq;

namespace AMLLC.CORE.BUSINESS.Login
{
    public class LoginLogic
    {
        LoginResponseDataManager loginResponseDataManager;

        public LoginLogic()
        {
            loginResponseDataManager = new LoginResponseDataManager();
        }

        /// <summary>
        /// Valida si un usuario esta registrado en la base datos y en caso de existir que
        /// la contraseña enviada sea correcta
        /// </summary>
        /// <param name="request">Credenciales de login</param>
        /// <returns>Un objeto respuesto del tipo LoginResponseDTO.</returns>
        public ResponseDTO<LoginResponseDTO> ValidateUser(UserDTO request)
        {
            ResponseDTO<List<LoginResponseDTO>> responseList = loginResponseDataManager.GetByUser(request);
            ResponseDTO<LoginResponseDTO> response = new ResponseDTO<LoginResponseDTO>();


            //Valida que la contraseña sea correcta si se obtuvo al usuario correctamente
            if (responseList.Success)
            {
                //Si el usuario tiene mas de un un rol asignado, se valida si tiene el rol de administrador, 
                //en caso de que no exista se envia el rol de supervisor.
                if (responseList.Result.Count > 1)
                {
                    var query = from p in responseList.Result
                                where p.Role.IdRole == 1
                                select p;
                    response.Result = query.First();
                }
                if (response.Result == null)
                {
                    response.Result = responseList.Result.First();
                }
                
                //Se valida que la contraseña enviada sea correcta
                response.Result.IsAuthenticated = HashEncryption.VerifyHashPassword(response.Result.User.Password, request.Password);
                response.Result.User.Password = string.Empty;
            }
            if (!response.Result.IsAuthenticated)
            {
                response.Result = null;
                response.Success = false;
                response.Message = "Username or Password incorrect.";
            }
            return response;
        }
    }
}