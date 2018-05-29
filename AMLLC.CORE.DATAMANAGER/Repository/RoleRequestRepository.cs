using AMLLC.CORE.DATA;
using AMLLC.CORE.DATAMANAGER.Mapper;
using AMLLC.CORE.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.DATAMANAGER
{
    public class RoleRequestRepository : IRepository<int, CatalogsDTO, RequestCatalogDTO>
    {
        #region "Global variables"
        Database database;
        DatabaseType databaseType;
        #endregion

        #region "Constructor"
        public RoleRequestRepository()
        {
            databaseType = DatabaseType.SqlServer;
        }
        #endregion

        #region "Interface Implementation"
        public ResponseDTO<int> Add(CatalogsDTO entity)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO<IEnumerable<CatalogsDTO>> GetAll(RequestCatalogDTO filter)
        {
            ResponseDTO<IEnumerable<CatalogsDTO>> response = new ResponseDTO<IEnumerable<CatalogsDTO>>();
            ResponseDTO<List<CatalogsDTO>> responseList = Get(filter.IncludeDisabled, filter.Id);

            response.Message = responseList.Message;
            response.Success = responseList.Success;

            if (responseList.Success)
                response.Result = responseList.Result.AsEnumerable();

            return response;
        }

        public ResponseDTO<CatalogsDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO<int> Update(CatalogsDTO entity)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region "Methods"
        /// <summary>
        /// Obtiene una lista de lista de todas las compañias registradas en la base de datos
        /// </summary>
        /// <param name="IncludeDisabled">Parametro donde se indica si se obtendran los registros deshabilitados</param>
        /// <param name="CompanyId">Parametro donde se indica el número de Id de la compañia a obtener</param>
        /// <returns>Objeto de tipo ResponseDTO con el listado de las compañias obtenidas</returns>
        private ResponseDTO<List<CatalogsDTO>> Get(bool IncludeDisabled, int? RoleId = null)
        {
            database = DatabaseFactory.CreateDataBase(databaseType, "[USER].[USP_GET_ROLES]", IncludeDisabled, RoleId);
            ResponseDTO<List<CatalogsDTO>> response = CommonMapper.CatalogsMapper(database.DataReader);
            database.Connection.Close();

            return response;
        }
        #endregion
    }
}
