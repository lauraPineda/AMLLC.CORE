using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.DATA
{
    public class SQLServerDatabase : Database
    {
        public System.Data.Common.DbConnection _Connection;
        public System.Data.Common.DbCommand _Command;

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

    }
}
