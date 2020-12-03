using Microsoft.AspNetCore.Mvc;
using ajWebSite.Common.DTOs.Security;
using ajWebSite.Services.Contracts.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ajWebSite.Areas.AdminPanel.Controllers
{

    [Route("AdminPanel/[Controller]/[Action]")]
    public class userController: BaseControllerClass
    {
        IUserBiz _userBiz;
        public userController(IUserBiz userBiz)
        {
            _userBiz = userBiz;
        }
        public ActionResult Index()
        { 
            return View("~/Areas/AdminPanel/Views/user/Index.cshtml");
        }    
        public async Task<ActionResult> getUsers()
        { 
            return Ok(_userBiz.getUsers());  
        }
        public async Task<ActionResult> saveUser(UserInfoDTO model)
        {
            var result = await runTaskAsync<Boolean>(async () =>
            {
                var operationResult = false;
                try
                {
                    if (model.Id>0)
                    {
                        var message = "";
                        _userBiz.UpdateUser(model,out message);
                        if (message.Length>0)
                        {
                            throw new Exception(message);
                        }
                        operationResult = true;
                    }
                    else
                    {
                        var message = "";
                        _userBiz.CreateUser(model, out message);
                        if (message.Length > 0)
                        {
                            throw new Exception(message);
                        }
                        operationResult = true;
                    }
                }
                catch (Exception)
                {
                    operationResult = false;
                }
                return operationResult;
            });
            return Ok(result);
        }
    }
}
