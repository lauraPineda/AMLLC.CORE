
using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.DB;
using AMLLC.CORE.ENTITIES.Login;
using AMLLC.CORE.SHARED;

namespace AMLLC.CORE.BUSINESS.Login
{
    public class LoginLogic
    {
        LoginDataManger loginDataManger;
        private static LoginLogic instance;
        private static readonly object _Lock = new object();

        /// <summary>
        /// Obtiene una instancia de la clase LoginLogic mediante Singleton.
        /// </summary>
        /// <returns>Retorna una instancia del tipo LoginLogic.</returns>
        public static LoginLogic GetInstance
        {
            get
            {
                lock (_Lock)
                {
                    if (Equals(instance, null))
                    {
                        instance = new LoginLogic();
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Obtiene autorización de usuario.
        /// </summary>
        /// <param name="request">Credenciales de login</param>
        /// <returns>Un objeto respuesto del tipo LoginDTO.</returns>
        public ResponseDTO<LoginResponseDTO> GetLogin(UserDTO request)
        {
            ResponseDTO<LoginResponseDTO> response=loginDataManger.LoginSupervisor(request);

            //Valida que la contraseña sea correcta
            response.Result.IsAuthenticated=HashEncryption.VerifyHashPassword(response.Result.User.Password,request.Password);
            response.Result.User.Password = string.Empty;
            return response;
        }
    }
}