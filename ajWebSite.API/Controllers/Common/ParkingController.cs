using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ajWebSite.Common.DTOs;
using ajWebSite.Common.DTOs.Common;
using ajWebSite.Core.Biz;
using ajWebSite.Core.Contracts.Entities;
using ajWebSite.Services.Contracts.Common;

namespace ajWebSite.API.Controllers.Common
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ParkingController : CRUDBaseApiController<ParkingDTO>
    {
        private IParkingBiz _parkingBiz;

        public ParkingController(IParkingBiz parkingBiz) : base(parkingBiz)
        {
            _parkingBiz = parkingBiz;
        }

        [HttpPost]
        public IActionResult GetPaginated(PaginatedRequest search)
        {
            return Okk(_parkingBiz.GetAllPaginated(search));
        }

 
    }
}