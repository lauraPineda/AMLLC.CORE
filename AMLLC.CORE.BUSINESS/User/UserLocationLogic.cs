using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.DB;

namespace AMLLC.CORE.BUSINESS.User
{
    public class UserLocationLogic
    {
        UserDataManager userDataManager;
        private static UserLocationLogic instance;
        private static readonly object _Lock = new object();

        private UserLocationLogic()
        {
            userDataManager = new UserDataManager();
        }

        /// <summary>
        /// Obtiene una instancia de la clase AddUser mediante Singleton.
        /// </summary>
        /// <returns>Regresa una instancia del tipo AddUser.</returns>
        public static UserLocationLogic GetInstance
        {
            get
            {
                lock (_Lock)
                {
                    if (Equals(instance, null))
                    {
                        instance = new UserLocationLogic();
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
        public ResponseDTO<int> AddUserLocation(UserLocationRolDTO request)
        {

            ResponseDTO<int> response= userDataManager.AddUserLocation(request);

            if (response.Result > 0)
                response.Success = true;
            else {
                response.Success = false;
                response.Message = "Something went wrong when trying to add the location to the user.";
            }
            return response;
        }
    }
}
