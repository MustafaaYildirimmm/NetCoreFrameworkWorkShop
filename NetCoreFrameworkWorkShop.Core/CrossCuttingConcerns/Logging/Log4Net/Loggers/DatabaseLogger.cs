using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreFrameworkWorkShop.Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class DatabaseLogger : LoggerServiceBase
    {
        public DatabaseLogger() : base("DatabaseLogger")
        {
                
        }
    }
}
