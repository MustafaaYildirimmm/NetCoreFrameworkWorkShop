using Microsoft.Extensions.DependencyInjection;
using NetCoreFrameworkWorkShop.Core.Utilities.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreFrameworkWorkShop.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolver (this IServiceCollection services,ICoreModule[] modules)
        {
            foreach (var  module in modules)
            {
                module.Load(services);
            }

            return ServiceTool.Create(services);
        }
    }
}
