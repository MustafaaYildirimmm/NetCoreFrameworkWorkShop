using NetCoreFrameworkWorkShop.Core.DataAccess;
using NetCoreFrameworkWorkShop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreFrameworkWorkShop.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {

    }
}
