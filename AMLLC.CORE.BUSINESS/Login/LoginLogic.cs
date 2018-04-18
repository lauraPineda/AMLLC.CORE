
using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.Login;
using AMLLC.CORE.SHARED;

namespace AMLLC.CORE.BUSINESS.Login
{
    public class LoginLogic
    {
        private static LoginLogic instance;

        /// <summary>
        /// Constructor privado para ser usado mediante singleton
        /// </summary>
        //public LoginLogic()
        //{
        //    instance = new LoginLogic();
        //}

        /// <summary>
        /// Obtiene una instancia de la clase LoginLogic mediante Singleton.
        /// </summary>
        /// <returns>Retorna una instancia del tipo LoginLogic.</returns>
        public static LoginLogic GetInstance()
        {
            if (Equals(instance, null))
            {
                instance = new LoginLogic();
            }
            return instance;
        }

        /// <summary>
        /// Obtiene autorización de usuario.
        /// </summary>
        /// <param name="request">Credenciales de login</param>
        /// <returns>Un objeto respuesto del tipo LoginDTO.</returns>
        public ResponseDTO<LoginDTO> GetLogin(LoginDTO request)
        {
            LoginDataManger loginDataManger = new LoginDataManger();
            ResponseDTO<LoginDTO> response=loginDataManger.LoginSupervisor(request);

            //Valida que la contraseña sea correcta
            response.Result.IsAuthenticated=HashEncryption.VerifyHashPassword(response.Result.User.Password,request.User.Password);

            return response;
        }
    }
}