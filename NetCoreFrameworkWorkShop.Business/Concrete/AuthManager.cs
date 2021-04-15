using NetCoreFrameworkWorkShop.Business.Abstract;
using NetCoreFrameworkWorkShop.Business.Constants;
using NetCoreFrameworkWorkShop.Core.Entities.Concrete;
using NetCoreFrameworkWorkShop.Core.Utilities.Results;
using NetCoreFrameworkWorkShop.Core.Utilities.Security.Hashing;
using NetCoreFrameworkWorkShop.Core.Utilities.Security.JWT;
using NetCoreFrameworkWorkShop.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreFrameworkWorkShop.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CraeteAccessToken(User user)
        {
            var claims = _userService.GetClaim(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);

            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);

            if (userToCheck is null)  return new ErrorDataResult<User>(Messages.UserNotFound);

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt)) return new ErrorDataResult<User>(Messages.PasswordError);

            return new SuccessDataResult<User>(userToCheck,Messages.SuccesFullLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.Add(user);

            return new SuccessDataResult<User>(user, Messages.UserRegisterdSuccesfully);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null) return new ErrorDataResult<User>(Messages.UserAlreadyExists);

            return new SuccessResult(); 
        }
    }
}
