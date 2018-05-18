using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.SHARED;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.DATAMANAGER.Mapper
{
    public class CommonMapper
    {
        public static ResponseDTO<int> MapperId(DbDataReader DbDataReader)
        {
            ResponseDTO<int> response = new ResponseDTO<int>();
            response.Success = true;

            if (DbDataReader.HasRows)
            {
                while (DbDataReader.Read())
                {
                    response.Result = Helper.GetInt32(DbDataReader, "Id");
                }

            }
            else
            {
                response.Success = false;
                response.Message = "There was an error loading the Id.";
            };

            return response;
        }

        public static ResponseDTO<int> GetRecordsAffected(DbDataReader DbDataReader)
        {

            ResponseDTO<int> response = new ResponseDTO<int>();

            response.Result = DbDataReader.RecordsAffected;

            response.Success = response.Result > 0 ? true : false;

            response.Message = response.Success == false ? "An error occured while updating" : null;
            return response;
        }
    }
}
