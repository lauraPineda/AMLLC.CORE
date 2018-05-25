using AMLLC.CORE.BUSINESS;
using AMLLC.CORE.DATAMANAGER;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.ENTITIES.Catalog;
using AMLLC.CORE.SHARED;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace AMLLC.CORE.WEBAPI.Controllers
{
    [RoutePrefix("Company")]
    public class CompanyController : ApiController
    {
        #region "Global variables"
        CompanyLogic companyLogic;
        #endregion

        #region "Constructor"
        public CompanyController(IRepository<int, CatalogsDTO,bool> repository)
        {
            companyLogic = new CompanyLogic(repository);
        }
        #endregion

        [HttpPost]
        [Route("GetById")]
        public ResponseDTO<CatalogsDTO> GetById(RequestDTO<int> request)
        {
            var response = new ResponseDTO<CatalogsDTO>();
            try
            {
                response = companyLogic.GetById(request.Signature);
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
        [Route("GetAll")]
        public ResponseDTO<IEnumerable<CatalogsDTO>> GetAll(RequestDTO<Boolean> request)
        {
            var response = new ResponseDTO<IEnumerable<CatalogsDTO>>();
            try
            {
                response = companyLogic.GetAll(request.Signature);
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
        [Route("Add")]
        public ResponseDTO<int> AddCompany(RequestDTO<CatalogsDTO> request)
        {
            var response = new ResponseDTO<int>();
            try
            {
                response = companyLogic.Add(request.Signature);
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

        /// <summary>
        /// Actualiza la información de un usuario
        /// </summary>
        /// <param name="request">UserRequestDTO</param>
        /// <returns>Número de registros afectados</returns>
        [HttpPost]
        [Route("Update")]
        public ResponseDTO<int> UpdateCompany(RequestDTO<CatalogsDTO> request)
        {
            var response = new ResponseDTO<int>();
            try
            {
                response = companyLogic.Update(request.Signature);
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
