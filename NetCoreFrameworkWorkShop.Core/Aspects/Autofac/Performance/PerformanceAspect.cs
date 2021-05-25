using Castle.DynamicProxy;
using NetCoreFrameworkWorkShop.Core.Utilities.Interceptors;
using NetCoreFrameworkWorkShop.Core.Utilities.Ioc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreFrameworkWorkShop.Core.Aspects
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopWatch;

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopWatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _stopWatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopWatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name} ---> {_stopWatch.Elapsed.TotalSeconds}");
            }
        }
    }
}
