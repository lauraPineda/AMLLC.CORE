using AMLLC.CORE.BUSINESS;
using AMLLC.CORE.BUSINESS.Company;
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
    [RoutePrefix("Supervisor/Catalog")]
    public class CatalogController : ApiController
    {
        CatalogLogic catalogLogic;
        
        [HttpPost]
        [Route("GetRoles")]
        public ResponseDTO<List<CatalogsDTO>> ListRoles(RequestDTO<RequestCatalogDTO> request)
        {
            var response = new ResponseDTO<List<CatalogsDTO>>();
            try
            {
                catalogLogic = new CatalogLogic();
                response = catalogLogic.GetListCatalog(request.Signature, CatalogEnum.Catalogs.Roles);
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

        [HttpPost]
        [Route("GetCompanyClients")]
        public ResponseDTO<List<CatalogsDTO>> ListCompanyClients(RequestDTO<RequestCompanyClientsDTO> request)
        {
            var response = new ResponseDTO<List<CatalogsDTO>>();
            try
            {
                catalogLogic = new CatalogLogic();
                response = catalogLogic.GetListCompanyClients(request.Signature);
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
        [HttpPost]
        [Route("GetClientsProjects")]
        public ResponseDTO<List<ProjectDTO>> ListClientsProject(RequestDTO<RequestClientProjectDTO> request)
        {
            var response = new ResponseDTO<List<ProjectDTO>>();
            try
            {
                catalogLogic = new CatalogLogic();
                response = catalogLogic.GetClientProjects(request.Signature);
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

        [HttpPost]
        [Route("GetProjectsLocations")]
        public ResponseDTO<List<LocationDTO>> ListProjectsLocations(RequestDTO<RequestProjectLocationsDTO> request)
        {
            var response = new ResponseDTO<List<LocationDTO>>();
            try
            {
                catalogLogic = new CatalogLogic();
                response = catalogLogic.GetProjectsLocations(request.Signature);
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

        [HttpPost]
        [Route("GetLocationSupervisors")]
        public ResponseDTO<List<InfoDTO>> ListLocationSupervisors(RequestDTO<RequestLocationSupervisorsDTO> request)
        {
            var response = new ResponseDTO<List<InfoDTO>>();
            try
            {
                catalogLogic = new CatalogLogic();
                response = catalogLogic.GetLocationSupervisors(request.Signature);
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

        [HttpPost]
        [Route("GetSupervisorWorkers")]
        public ResponseDTO<List<InfoDTO>> ListLocationSupervisors(RequestDTO<UserDTO> request)
        {
            var response = new ResponseDTO<List<InfoDTO>>();
            try
            {
                catalogLogic = new CatalogLogic();
                response = catalogLogic.GetSupervisorWorkers(request.Signature);
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
