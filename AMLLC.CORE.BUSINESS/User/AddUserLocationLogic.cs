using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.DB;

namespace AMLLC.CORE.BUSINESS.User
{
    public class AddUserLocationLogic
    {
        UserDataManager userDataManager;
        private static AddUserLocationLogic instance;
        private static readonly object _Lock = new object();

        private AddUserLocationLogic()
        {
            userDataManager = new UserDataManager();
        }

        /// <summary>
        /// Obtiene una instancia de la clase AddUser mediante Singleton.
        /// </summary>
        /// <returns>Regresa una instancia del tipo AddUser.</returns>
        public static AddUserLocationLogic GetInstance
        {
            get
            {
                lock (_Lock)
                {
                    if (Equals(instance, null))
                    {
                        instance = new AddUserLocationLogic();
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
        public ResponseDTO<object> AddUserLocation(UserLocationRolDTO request)
        {

            ResponseDTO<object> response= userDataManager.AddUserLocation(request);

            return response;
        }
    }
}
