using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ajWebSite.Common.DTOs;
using ajWebSite.Common.DTOs.Security;
using ajWebSite.Services.Contracts.Security;
//Authorization Bearer 1111
namespace ajWebSite.API.Controllers.Security
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : BaseApiController
    {
        private IUserBiz _userBiz;
        private readonly IConfiguration _config;

        public AuthController(IUserBiz userBiz, IConfiguration config)
        {
            _userBiz = userBiz;
            _config = config;
        }

        [AllowAnonymous]
        public IActionResult Register(RegisterDTO dto)
        {
            var userInfo = _userBiz.Register(dto, out var message, out var claims);
            if (userInfo != null)
            {
                return GetToken(userInfo, claims);

            }
            else
            {
                return Ok(new { succeed = false, errorMessage = message });
            }

        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var userFromRepo = _userBiz.Login(loginDTO, out var claims);
            if (userFromRepo == null) //User login failed
                return Ok(new BaseResponse("نام کاربری یا رمز ورود اشتباه است"));

            //generate token
            return GetToken(userFromRepo, claims);
        }


        private IActionResult GetToken(UserInfoDTO user, List<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Secret").Value);
            var expires = DateTime.Now.AddDays(1);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new BaseResponse()
            {
                Succeed = true,
                Data = new
                {
                    User = user,
                    Token = tokenString,
                    ExpireDate = expires
                }
            });
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult RegisterSendCode(SmsActivation entity)
        {
            var succeed = _userBiz.RegisterSendCode(entity.Mobile, out var error);

            return Okk(succeed, error);
        }
        [AllowAnonymous]
        public IActionResult RegisterCheckCode(SmsActivation entity)
        {
            var succeed = _userBiz.RegisterCheckCode(entity.Mobile, entity.Code);

            return Okk(succeed, "کد وارد شده صحیح نیست");
        }
    }
}