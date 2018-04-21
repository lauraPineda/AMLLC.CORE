using System.Data.Common;

namespace AMLLC.CORE.DATA
{
    public abstract class Database
    {
        public virtual DbConnection Connection { get; set; }
        public virtual DbCommand Command { get; set; }
        public virtual DbDataReader DataReader { get; set; }

    }
}
