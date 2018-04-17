using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.DATA
{
    public interface IDatabaseBuilder
    {
        void BuildConnection();
        void BuildCommand(string sStoredProcedure);
        void SetSettings();
        void AddParameters(object[] arrobjParameters);
        void GetDataReader();
        //solo de lectura por lo tanto solo se implementa el get
        Database Database { get; }
    }
}
