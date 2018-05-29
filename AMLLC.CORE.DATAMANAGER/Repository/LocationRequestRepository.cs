using AMLLC.CORE.DATA;
using AMLLC.CORE.DATAMANAGER.Mapper;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.Catalog;
using AMLLC.CORE.ENTITIES.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.DATAMANAGER
{
    public class LocationRequestRepository : IRepository<int, LocationDTO, RequestLocationsDTO>
    {
        #region "Global variables"
        Database database;
        DatabaseType databaseType;
        #endregion

        #region "Constructor"
        public LocationRequestRepository()
        {
            databaseType = DatabaseType.SqlServer;
        }
        #endregion

        public ResponseDTO<int> Add(LocationDTO entity)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO<IEnumerable<LocationDTO>> GetAll(RequestLocationsDTO filter)
        {
            ResponseDTO<IEnumerable<LocationDTO>> response = new ResponseDTO<IEnumerable<LocationDTO>>();
            ResponseDTO<List<LocationDTO>> responseList = Get(filter.Location.IncludeDisabled, filter.IdProject);

            response.Message = responseList.Message;
            response.Success = responseList.Success;

            if (responseList.Success)
                response.Result = responseList.Result.AsEnumerable();

            return response;
        }

        public ResponseDTO<LocationDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO<int> Update(LocationDTO entity)
        {
            throw new NotImplementedException();
        }

        #region "Methods"
        /// <summary>
        /// Obtiene una lista de lista de todas las compañias registradas en la base de datos
        /// </summary>
        /// <param name="IncludeDisabled">Parametro donde se indica si se obtendran los registros deshabilitados</param>
        /// <param name="CompanyId">Parametro donde se indica el número de Id de la compañia a obtener</param>
        /// <returns>Objeto de tipo ResponseDTO con el listado de las compañias obtenidas</returns>
        private ResponseDTO<List<LocationDTO>> Get(bool IncludeDisabled, int? ProyectId = null, int? LocationId = null)
        {
            database = DatabaseFactory.CreateDataBase(databaseType, "[CLIENT].[USP_GET_LOCATIONS]", IncludeDisabled, ProyectId, LocationId);
            ResponseDTO<List<LocationDTO>> response = LocationMapper.MapperLocationDTO(database.DataReader);
            database.Connection.Close();

            return response;
        }
        #endregion
    }
}
