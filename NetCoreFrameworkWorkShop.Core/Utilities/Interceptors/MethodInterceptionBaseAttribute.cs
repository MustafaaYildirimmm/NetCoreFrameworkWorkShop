using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreFrameworkWorkShop.Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method , AllowMultiple = true , Inherited =true)]
    public class MethodInterceptionBaseAttribute : Attribute,IInterceptor
    {
        public int Priorty { get; set; }



        public virtual void Intercept(IInvocation invocation)
        {
            
        }
    }
}
