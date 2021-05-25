using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreFrameworkWorkShop.Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class FileLogger : LoggerServiceBase
    {
        public FileLogger() : base("JsonFileLogger")
        {

        }
    }
}
