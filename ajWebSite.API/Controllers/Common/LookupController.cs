using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ajWebSite.Common.DTOs;
using ajWebSite.Common.DTOs.Common;
using ajWebSite.Core.Biz;
using ajWebSite.Services.Contracts.Common;

namespace ajWebSite.API.Controllers.Common
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LookupController : CRUDBaseApiController<LookupDTO>
    {
        private ILookupBiz _lookupBiz;

        public LookupController(ILookupBiz lookupBiz) : base(lookupBiz)
        {
            _lookupBiz = lookupBiz;
        }

        [HttpPost]
        public IActionResult GetPaginated(LookupSearch search)
        {
            return Okk(_lookupBiz.GetPaginated(search));
        }

 
    }
}