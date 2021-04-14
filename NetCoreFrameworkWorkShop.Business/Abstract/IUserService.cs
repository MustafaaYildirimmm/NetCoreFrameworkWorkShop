using NetCoreFrameworkWorkShop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreFrameworkWorkShop.Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaim(User user);
        void Add(User user);
        User GetByMail(string email);
    }
}
