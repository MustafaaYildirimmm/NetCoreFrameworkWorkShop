using Microsoft.AspNetCore.Mvc;
using NetCoreFrameworkWorkShop.Business.Abstract;
using NetCoreFrameworkWorkShop.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreFrameworkWorkShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);

            if (!userToLogin.Success) return BadRequest(userToLogin.Message);

            var result = _authService.CraeteAccessToken(userToLogin.Data);
            
            if (result.Success) return Ok(result.Data);

            return BadRequest(result.Message); 
        }


        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);

            if (!userExists.Success) return BadRequest(userExists.Message);

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CraeteAccessToken(registerResult.Data);

            if (registerResult.Success) return Ok(result.Data);

            return BadRequest(result.Message);
        }
    }
}
