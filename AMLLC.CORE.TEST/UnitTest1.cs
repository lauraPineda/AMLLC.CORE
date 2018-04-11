using AMLLC.CORE.DATA;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;

namespace AMLLC.CORE.TEST
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            Database database;
            DatabaseType databaseType = DatabaseType.SqlServer;
            database = DatabaseFactory.CreateDataBase(databaseType);

            DbCommand command = database.Command;


        }
    }
}
