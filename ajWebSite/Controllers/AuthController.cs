using ajWebSite.Areas.AdminPanel.Controllers;
using ajWebSite.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ajWebSite.Common.DTOs.Security;
using ajWebSite.Core.Module;
using ajWebSite.Services.Contracts.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ajWebSite.Controllers
{
    public class AuthController : BaseControllerClass
    {
        private currentConfig _config;
        private readonly ILogger<HomeController> _logger;
        private IUserBiz _IUserBiz;
        public AuthController(ILogger<HomeController> logger, currentConfig config, IUserBiz IUserBiz)
        {
            _config = config;
            _logger = logger;
            _IUserBiz = IUserBiz;
        }
        public ActionResult RegisterUser(RegisterUserModel model)
        {
            
            return View(model);
        }
        [AllowAnonymous]
        public async Task<ActionResult> registerNewUser(UserInfoDTO model)
        {
            var result= await runTaskAsync<UserInfoDTO>(async () =>
            {
                string resultMessage = "";
                if(_IUserBiz.CreateUser(model,out resultMessage))
                {
                    return model;
                }
                else
                {
                    throw new Exception(resultMessage);
                }
            });
            return Ok(result);
        }
    }
}
