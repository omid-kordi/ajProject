using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ajWebSite.Common.DTOs;
using ajWebSite.Services.Contracts.Common;

namespace ajWebSite.API.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : BaseApiController
    {
        private IFileBinaryBiz _fileBinaryBiz;

        public FileController(IFileBinaryBiz fileBinaryBiz)
        {
            _fileBinaryBiz = fileBinaryBiz;
        }

        [AllowAnonymous]
        [HttpGet("GetFile/{uid}")]
        public FileResult GetFile(string uid)
        {
            var file = _fileBinaryBiz.GetFile(uid, out var name);
            return File(file, "application/octet-stream", name);
        }

        //[AllowAnonymous]
        //[HttpGet("GetFile/{id}")]
        //public FileResult GetFile(int id)
        //{
        //    var path = @"C:\Users\user\source\repos\2019\ajWebSite\ajWebSite.API\wwwroot\files";
        //    var i = id % 8;
        //    var file = System.IO.File.ReadAllBytes($"{path}/{i}.jpg");

        //    return File(file, "image/jpg");
        //}

        [AllowAnonymous]
        [HttpPost("Upload"), DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            var file = Request.Form.Files[0];
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var bytes = await GetBytes(file);
                var uid =_fileBinaryBiz.Insert(fileName, bytes);
                return Ok(new BaseResponse() {Succeed = true, Data = uid});
            }
            else
            {
                return Okk("خطا");
            }
        }


        public async Task<byte[]> GetBytes(IFormFile formFile)
        {
            await using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }


    }
}