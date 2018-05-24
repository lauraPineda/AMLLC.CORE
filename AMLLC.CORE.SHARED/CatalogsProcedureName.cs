using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AMLLC.CORE.SHARED.CatalogEnum;

namespace AMLLC.CORE.SHARED
{
    public class CatalogsProcedureName
    {
        public static string Get(Catalogs catalog)
        {
            switch (catalog)
            {
                case Catalogs.Company:
                    return "[CLIENT].[USP_GET_COMPANIES]";
                case Catalogs.Roles:
                    return "[USER].[USP_GET_ROLES]";
                default:
                    return string.Empty;

            }
        }
    }
}
