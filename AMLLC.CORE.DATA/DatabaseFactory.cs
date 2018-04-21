namespace AMLLC.CORE.DATA
{
    public class DatabaseFactory
    {
        public static Database CreateDataBase(DatabaseType databaseType,string sStoredProcedure, params object[] arrobjParameters)
        {
            switch (databaseType)
            {
                case DatabaseType.SqlServer:
                default:
                    Director director = new Director();
                    IDatabaseBuilder builder;

                    builder = new SqlServerDatabaseBuilder();

                    director.Build(builder, sStoredProcedure,arrobjParameters);

                    return builder.Database;

            }
        }
    }
}
