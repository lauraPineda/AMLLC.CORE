using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.DB;
using AMLLC.CORE.ENTITIES.User;
using AMLLC.CORE.SHARED;

namespace AMLLC.CORE.BUSINESS.User
{
    public class AddUserLogic
    {
        UserDataManager userDataManager;
        private static AddUserLogic instance;
        private static readonly object _Lock = new object();

        private AddUserLogic()
        {
            userDataManager = new UserDataManager();
        }

        /// <summary>
        /// Obtiene una instancia de la clase AddUser mediante Singleton.
        /// </summary>
        /// <returns>Regresa una instancia del tipo AddUser.</returns>
        public static AddUserLogic GetInstance
        {
            get
            {
                lock (_Lock)
                {
                    if (Equals(instance, null))
                    {
                        instance = new AddUserLogic();
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Se agrega información de usuarios nuevos
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Regresa ibjeto de tipo UserDTO</returns>
        public ResponseDTO<UserDTO> AddUser(AddUserResponseDTO request)
        {
            request.User.Password = HashEncryption.Hash(request.User.Password);

            ResponseDTO<UserDTO> response = userDataManager.AddUser(request);
            
            return response;
        }
    }
}
