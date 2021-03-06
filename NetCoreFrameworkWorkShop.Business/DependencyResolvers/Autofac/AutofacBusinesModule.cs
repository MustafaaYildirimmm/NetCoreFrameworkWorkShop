using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using NetCoreFrameworkWorkShop.Business.Abstract;
using NetCoreFrameworkWorkShop.Business.Concrete;
using NetCoreFrameworkWorkShop.Core.Utilities.Interceptors;
using NetCoreFrameworkWorkShop.Core.Utilities.Security.JWT;
using NetCoreFrameworkWorkShop.DataAccess.Abstract;
using NetCoreFrameworkWorkShop.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreFrameworkWorkShop.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();

        }
    }
}
