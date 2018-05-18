
using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.DB;
using AMLLC.CORE.ENTITIES.Login;
using AMLLC.CORE.SHARED;

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
            ResponseDTO<LoginResponseDTO> response= loginResponseDataManager.GetByUser(request);

            //Valida que la contraseña sea correcta si se obtuvo al usuario correctamente
            if (response.Success)
            {
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