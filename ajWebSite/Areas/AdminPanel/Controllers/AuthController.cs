using AutoMapper.Configuration;
using ajWebSite.Areas.AdminPanel.Models.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ajWebSite.Common.DTOs.Security;
using ajWebSite.Core.Module;
using ajWebSite.Services.Contracts.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims; 
using System.Threading.Tasks;

namespace ajWebSite.Areas.AdminPanel.Controllers
{
    [Route("AdminPanel/[Controller]/[Action]")]
    public class AuthController : Controller
    {
        private IUserBiz _userBiz;
        public AuthController( IUserBiz userBiz)
        {
            _userBiz = userBiz; 
        }
        [Authorize]
        public async Task<ActionResult> testLogin(loginModel model)
        {
            return View("~/Areas/AdminPanel/Views/Auth/testLogin.cshtml");
        }
        [AllowAnonymous] 
        public async Task<ActionResult> login(string ReturnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated != false)
            {
                return RedirectPermanent(ReturnUrl);
            }
            return View("~/Areas/AdminPanel/Views/Auth/login.cshtml");
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> loginP(string ReturnUrl, loginModel model)
        {
            var userFromRepo = _userBiz.Login(new LoginDTO()
            {
                Password = model.passWord,
                Username = model.userName
            }, out var claims);
            if (userFromRepo == null) //User login failed
            {
                return new JsonResult("false");
                //return RedirectToAction("login",new { ReturnUrl= ReturnUrl });
            }
            else
            {
                var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, userFromRepo.Username));
                identity.AddClaim(new Claim(CustomClaim.PersonId, userFromRepo.PersonId.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.GivenName, userFromRepo.Name));
                identity.AddClaim(new Claim(CustomClaim.CompanyId, userFromRepo.CompanyId.ToString()));
                identity.AddClaim(new Claim(CustomClaim.userType, ((int)(userFromRepo.Type)).ToString()));
                await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                new ClaimsPrincipal(identity));
            }
                 
            return new JsonResult("true");
        } 
        public async Task<ActionResult> logOut(string ReturnUrl, loginModel model)
        {
            try
            {
                await HttpContext.SignOutAsync();
                return new JsonResult("true");
            }
            catch (Exception ex)
            {
                return new JsonResult("false"); 
            }
        } 
        public async Task<ActionResult> logOutWithUrl(string ReturnUrl, loginModel model)
        {
            try
            {
                await HttpContext.SignOutAsync();
                return RedirectPermanent(ReturnUrl);
            }
            catch (Exception ex)
            {
                return RedirectPermanent(Request.Path);
            }
        }
    }
}
