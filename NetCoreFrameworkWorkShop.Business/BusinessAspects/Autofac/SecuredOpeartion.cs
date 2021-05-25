using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using NetCoreFrameworkWorkShop.Core.Utilities.Interceptors;
using NetCoreFrameworkWorkShop.Core.Utilities.Ioc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreFrameworkWorkShop.Core.Extensions;
using NetCoreFrameworkWorkShop.Business.Constants;

namespace NetCoreFrameworkWorkShop.Business
{
    public class SecuredOpeartion : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOpeartion(string[] roles)
        {
            _roles = roles;
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }

                throw new Exception(Messages.AuthorizationDenied);
            }
        }
    }
}
