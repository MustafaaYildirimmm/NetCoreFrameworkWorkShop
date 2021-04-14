using NetCoreFrameworkWorkShop.Core.DataAccess.EntityFramework;
using NetCoreFrameworkWorkShop.DataAccess.Abstract;
using NetCoreFrameworkWorkShop.DataAccess.Concrete.EntityFramework.Contexts;
using NetCoreFrameworkWorkShop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreFrameworkWorkShop.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaim(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from operClaim in context.OperationClaims
                             join userOperClaim in context.UserOperationClaims
                             on operClaim.Id equals userOperClaim.OperationClaimId
                             where userOperClaim.UserId == user.Id
                             select new OperationClaim { Id = operClaim.Id, Name = operClaim.Name };

                return result.ToList();
            }
        }
    }
}
