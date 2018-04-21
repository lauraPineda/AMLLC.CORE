namespace AMLLC.CORE.DATA
{
    public class SQLServerDatabase : Database
    {
        private System.Data.Common.DbConnection _Connection = null;
        private System.Data.Common.DbCommand _Command = null;
        private System.Data.Common.DbDataReader _DataReader = null;

        public override System.Data.Common.DbConnection Connection
        {
            //No se implementa lazy loading ya que se implimenta en el builder
            get
            {
                return _Connection;
            }
            set
            {
                _Connection = value;
            }
        }

        public override System.Data.Common.DbCommand Command
        {
            get
            {
                return _Command;
            }
            set
            {
                _Command = value;
            }
        }

        public override System.Data.Common.DbDataReader DataReader
        {
            get
            {
                return _DataReader;
            }
            set
            {
                _DataReader = value;
            }
        }



    }
}
