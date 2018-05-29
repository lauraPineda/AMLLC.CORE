using AMLLC.CORE.BUSINESS;
using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.Catalog;
using AMLLC.CORE.ENTITIES.DB;
using AMLLC.CORE.SHARED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AMLLC.CORE.WEBAPI.Controllers
{
    [RoutePrefix("Location")]

    public class LocationController : ApiController
    {
        #region "Global variables"
        LocationLogic locationLogic;
        #endregion

        #region "Constructor"
        public LocationController(IRepository<int, LocationDTO, RequestLocationsDTO> repository)
        {
            locationLogic = new LocationLogic(repository);
        }
        #endregion


        [HttpPost]
        [Route("GetAll")]
        public ResponseDTO<IEnumerable<LocationDTO>> GetAll(RequestDTO<RequestLocationsDTO> request)
        {
            var response = new ResponseDTO<IEnumerable<LocationDTO>>();
            try
            {
                response = locationLogic.GetAll(request.Signature);
            }
            catch (System.Data.SqlClient.SqlException exception)
            {
                response.Success = false;
                response.Message = exception.Message;
                ExceptionHandler.Instance.WriteExceptionLog(exception);
            }
            catch (System.Exception exception)
            {
                response.Success = false;
                response.Message = exception.Message;
                ExceptionHandler.Instance.WriteExceptionLog(exception);
            }
            return response;
        }
    }
}
