using NetCoreFrameworkWorkShop.Core.Entities.Concrete;
using NetCoreFrameworkWorkShop.Core.Utilities.Results;
using NetCoreFrameworkWorkShop.Core.Utilities.Security.JWT;
using NetCoreFrameworkWorkShop.Entities.Dtos;

namespace NetCoreFrameworkWorkShop.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto,string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CraeteAccessToken(User user);
    }
}
