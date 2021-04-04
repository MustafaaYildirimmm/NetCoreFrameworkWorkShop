using Autofac;
using NetCoreFrameworkWorkShop.Business.Abstract;
using NetCoreFrameworkWorkShop.Business.Concrete;
using NetCoreFrameworkWorkShop.DataAccess.Abstract;
using NetCoreFrameworkWorkShop.DataAccess.EntityFramework;
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

        }
    }
}
