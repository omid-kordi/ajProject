using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ajWebSite.Common.DTOs;

namespace ajWebSite.API.Controllers
{
    [Authorize]
    public class BaseApiController : ControllerBase
    {


        public OkObjectResult Okk()
        {
            return Ok(new BaseResponse(true));
        }
        public OkObjectResult Okk(bool succeed,string errorMessage)
        {
            return Ok(new BaseResponse(succeed, errorMessage));
        }
        public OkObjectResult Okk(string errorMessage)
        {
            return Ok(new BaseResponse(errorMessage));
        }
        public OkObjectResult Okk(ModelStateDictionary modelState)
        {
            string errorMessage = string.Join("; ", ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage));
            return Ok(new BaseResponse { Succeed = false, ErrorMessage = errorMessage });
        }
        public OkObjectResult Okk(object data)
        {
            return Ok(new BaseResponse(data));
        }
    }
}