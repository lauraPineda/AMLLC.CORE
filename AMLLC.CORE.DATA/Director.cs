using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.DATA
{
    public class Director
    {
        public void Build(IDatabaseBuilder Builder)
        {
            Builder.BuildConnection();
            Builder.BuildCommand();
            Builder.SetSettings();
        }

    }
}
