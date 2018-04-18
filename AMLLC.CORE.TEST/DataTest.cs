using AMLLC.CORE.DATA;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.Common;

namespace AMLLC.CORE.TEST
{
    [TestClass]
    public class DataTest
    {
        object[] arrobjParameters;
        [TestMethod]
        public void TestBuilder()
        {

            Director director = new Director();
            IDatabaseBuilder builder;

            builder = new SqlServerDatabaseBuilder();

            director.Build(builder, "DBO.usp_test", arrobjParameters);

        }

        [TestMethod]
        public void TestFactoryMetod()
        {
            Database database; 
            DatabaseType databaseType = DatabaseType.SqlServer;
            database = DatabaseFactory.CreateDataBase(databaseType, "DBO.usp_test", arrobjParameters);
            database.Connection.Close();

        }
    }
}
