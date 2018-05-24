using AMLLC.CORE.DATA;
using AMLLC.CORE.DATAMANAGER.Mapper;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.DB;
using AMLLC.CORE.ENTITIES.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.DATAMANAGER
{
    public class LoginResponseDataManager
    {
        #region "Global variables"
        Database database;
        DatabaseType databaseType;
        #endregion

        #region "Constructor"
        public LoginResponseDataManager()
        {
            databaseType = DatabaseType.SqlServer;
        }
        #endregion

        #region "Methods"
        /// <summary>
        /// Obtiene la infarmación de un usuario con los roles de supervisor y/o administrador por medio de el nombre de usuario
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Objeto de tipo ResponseDTO con el listado de los roles de tipo supervisor y/o administrador asociados a un usuario</returns>
        public ResponseDTO<List<LoginResponseDTO>> GetByUser(UserDTO entity)
        {
            database = DatabaseFactory.CreateDataBase(databaseType, "[USER].[USP_GET_LOGININFO_SUPERVISOR]", entity.UserName.ToString());

            ResponseDTO<List<LoginResponseDTO>> response = LoginResponseMapper.MapperLoginDTO(database.DataReader);

            database.Connection.Close();

            return response;
        }
        #endregion
    }
}
