using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreFrameworkWorkShop.Core.Utilities.Ioc
{
    public interface ICoreModule
    {
        void Load(Microsoft.Extensions.DependencyInjection.IServiceCollection services);
    }
}
