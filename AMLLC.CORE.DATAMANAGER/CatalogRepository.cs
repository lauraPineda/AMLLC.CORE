using AMLLC.CORE.DATA;
using AMLLC.CORE.ENTITIES;
using AMLLC.CORE.SHARED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.DATAMANAGER
{
    public class CatalogRepository //: IRepository<int, ResponseCatalogDTO>
    {
        public int Add(CatalogsDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(CatalogsDTO entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CatalogsDTO> GetAll()

        {
            Database database;
            database = DatabaseFactory.CreateDataBase(DatabaseType.SqlServer, "[CLIENT].[USP_GET_COMPANIES]", 1,false);

            List < CatalogsDTO > response = new List<CatalogsDTO>();

            if (database.DataReader.HasRows)
            {
                while (database.DataReader.Read())
                {
                    response.Add(new CatalogsDTO
                    {
                        Id = Helper.GetInt32(database.DataReader, "Id"),
                        Name = Helper.GetString(database.DataReader, "Name"),
                        Description = Helper.GetString(database.DataReader, "Description"),
                        Enabled = Helper.GetBoolean(database.DataReader, "Enabled")
                    });
                }

            }

            IEnumerable<CatalogsDTO> numbers = response.AsEnumerable();
            return response;
        }

        public CatalogsDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CatalogsDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
