using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ajWebSite.Common.DTOs;
using ajWebSite.Common.DTOs.Common;
using ajWebSite.Common.DTOs.Security;
using ajWebSite.Common.Enums;
using ajWebSite.Services.Contracts.Common;
using ajWebSite.Services.Contracts.Security;

namespace ajWebSite.API.Controllers.Common
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        private IUserBiz _userBiz;

        public UserController(IUserBiz userBiz)
        {
            _userBiz = userBiz;
        }

        public IActionResult List(UserSearch search)
        {
            search.UserType = UserType.Personnel;
            return Okk(_userBiz.UserPaginated(search));
        }

        public IActionResult Create(UserInfoDTO user)
        {
            var succeed = _userBiz.CreateUser(user, out var errorMessage);

            return Okk(succeed, errorMessage);
        }

        public IActionResult Update(UserInfoDTO user)
        {
            var succeed = _userBiz.UpdateUser(user, out var errorMessage);

            return Okk(succeed, errorMessage);
        }

        public IActionResult Delete(IdRequest req)
        {
            _userBiz.DeleteUser(req.Id, UserType.Customer);

            return Okk();
        }

        public IActionResult Customers(UserSearch search)
        {
            search.UserType = UserType.Customer;
            return Okk(_userBiz.UserPaginated(search));
        }
    }
}