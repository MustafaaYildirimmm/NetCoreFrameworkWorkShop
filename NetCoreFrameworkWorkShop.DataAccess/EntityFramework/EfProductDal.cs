using NetCoreFrameworkWorkShop.Core.DataAccess.EntityFramework;
using NetCoreFrameworkWorkShop.DataAccess.Abstract;
using NetCoreFrameworkWorkShop.DataAccess.EntityFramework.Contexts;
using NetCoreFrameworkWorkShop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreFrameworkWorkShop.DataAccess.EntityFramework
{
    public class EfProductDal: EfEntityRepositoryBase<Product,NorthwindContext> ,IProductDal
    {
    }
}
