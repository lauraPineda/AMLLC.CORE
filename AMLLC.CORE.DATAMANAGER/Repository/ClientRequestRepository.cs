using AMLLC.CORE.DATA;
using AMLLC.CORE.DATAMANAGER.Mapper;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.RequestFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.DATAMANAGER
{
    public class ClientRequestRepository : IRepository<int, CatalogsDTO, CompanyFiltersDTO>
    {
        #region "Global variables"
        Database database;
        DatabaseType databaseType;
        #endregion

        #region "Constructor"
        public ClientRequestRepository()
        {
            databaseType = DatabaseType.SqlServer;
        }
        #endregion

        #region "Interface Implementation"
        /// <summary>
        /// Implementación de la intefaz para agregar una nueva compañia en la base de datos
        /// </summary>
        /// <param name="entity">Entidad de tipo </param>
        /// <returns>Objeto de tipo ResponseDTO con el número de registros afectados</returns>
        public ResponseDTO<int> Add(CatalogsDTO entity)
        {
            ResponseDTO<int> response = new ResponseDTO<int>();
            response.Success = true;

            database = DatabaseFactory.CreateDataBase(databaseType, "", entity.Name,
                                                                                                  entity.Description);

            response = CommonMapper.GetRecordsAffected(database.DataReader);

            database.Connection.Close();

            return response;
        }

        /// <summary>
        /// Implementación de la interfaz para obtener una lista de todas las compañias registradas en la base de datos
        /// </summary>
        /// <param name="IncludeDisabled">Parametro donde se indica si se obtendran los registros deshabilitados</param>
        /// <returns>Objeto de tipo ResponseDTO con el listado de las compañias obtenidas</returns>
        public ResponseDTO<IEnumerable<CatalogsDTO>> GetAll(CompanyFiltersDTO filter)
        {

            ResponseDTO<IEnumerable<CatalogsDTO>> response = new ResponseDTO<IEnumerable<CatalogsDTO>>();
            ResponseDTO<List<CatalogsDTO>> responseList = Get(filter.Client.IncludeDisabled,filter.IdCompany,null);

            response.Message = responseList.Message;
            response.Success = responseList.Success;

            if (responseList.Success)
                response.Result = responseList.Result.AsEnumerable();

            return response;

        }

        /// <summary>
        /// Implementación de la interfaz para obtener los datos de una compañia
        /// </summary>
        /// <param name="id">Parametro donde se indica el número de Id de la compañia a obtener</param>
        /// <returns>Objeto de tipo ResponseDTO con la información de las compañia obtenida</returns>
        public ResponseDTO<CatalogsDTO> GetById(int id)
        {
            ResponseDTO<CatalogsDTO> response = new ResponseDTO<CatalogsDTO>();
            //ResponseDTO<List<CatalogsDTO>> responseList = Get(true, id);

            //if (responseList.Success)
            //    response.Result = responseList.Result.FirstOrDefault();
            return response;
        }

        /// <summary>
        /// Implementación de la interfaz para actualizar la información de una compañia
        /// </summary>
        /// <param name="entity">Parametro de tipo CatalogsDTO donde se envia los cambios a realizar a la compañia</param>
        /// <returns>Objeto de tipo ResponseDTO con el número de registros afectados</returns>
        public ResponseDTO<int> Update(CatalogsDTO entity)
        {
            database = DatabaseFactory.CreateDataBase(databaseType, "", entity.Id,
                                                                                                        entity.Name,
                                                                                                        entity.Description,
                                                                                                        entity.Enabled);
            ResponseDTO<int> response = CommonMapper.GetRecordsAffected(database.DataReader);

            database.Connection.Close();

            return response;
        }
        #endregion

        #region "Methods"
        /// <summary>
        /// Obtiene una lista de lista de todas las compañias registradas en la base de datos
        /// </summary>
        /// <param name="IncludeDisabled">Parametro donde se indica si se obtendran los registros deshabilitados</param>
        /// <param name="CompanyId">Parametro donde se indica el número de Id de la compañia a obtener</param>
        /// <returns>Objeto de tipo ResponseDTO con el listado de las compañias obtenidas</returns>
        private ResponseDTO<List<CatalogsDTO>> Get(bool IncludeDisabled, int? CompanyId, int? ClientId)
        {
            database = DatabaseFactory.CreateDataBase(databaseType, "[CLIENT].[USP_GET_COMPANIES]", IncludeDisabled, CompanyId, ClientId);
            ResponseDTO<List<CatalogsDTO>> response = CommonMapper.CatalogsMapper(database.DataReader);
            database.Connection.Close();

            return response;
        }
        #endregion
    }
}
