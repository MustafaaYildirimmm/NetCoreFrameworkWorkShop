using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NetCoreFrameworkWorkShop.Core.CrossCuttingConcerns.Caching;
using NetCoreFrameworkWorkShop.Core.CrossCuttingConcerns.Caching.Microsoft;
using NetCoreFrameworkWorkShop.Core.Utilities.Ioc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreFrameworkWorkShop.Core.DependencyResolver
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemorycacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();
        }
    }
}
