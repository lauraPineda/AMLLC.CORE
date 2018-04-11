using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.DATA
{
    public class DatabaseFactory
    {
        public static Database CreateDataBase(DatabaseType databaseType)
        {
            switch (databaseType)
            {
                case DatabaseType.SqlServer:
                default:
                    Director director = new Director();
                    IDatabaseBuilder builder;

                    builder = new SqlServerDatabaseBuilder();


                    director.Build(builder);
                    Database database = builder.Database;
                    return database;
            }
        }
    }
}
