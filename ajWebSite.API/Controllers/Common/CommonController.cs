using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ajWebSite.Common.Configuration;
using ajWebSite.Common.DTOs.Common;
using ajWebSite.Common.Helpers;
using ajWebSite.Services.Contracts.Common;
using SepInit;

namespace ajWebSite.API.Controllers.Common
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommonController : BaseApiController
    {
        private ILookupBiz _lookupBiz;
        private SepPaymentConfiguration sepConfig;
        public CommonController(ILookupBiz lookupBiz, SepPaymentConfiguration sepConfig)
        {
            _lookupBiz = lookupBiz;
            this.sepConfig = sepConfig;
        }


        public IActionResult Test()
        {
            return Content("Wirking...");
        }


        public IActionResult TestBank()
        {
            var service = new PaymentIFBindingSoapClient(PaymentIFBindingSoapClient.EndpointConfiguration.PaymentIFBindingSoap);
            string token = service.RequestTokenAsync(sepConfig.TermId, "100000012", 1000, 0, 0, 0, 0, 0, 0, "", "", 0, "").Result;
            return Okk(new { PaymentUrl = sepConfig.PaymentUrl, Token = token });
        }


        [HttpPost]
        public IActionResult GetEnumSelectData(DropdownEnumSelect select)
        {
            var data = EnumHelper.GetByName(select.EnumType).Select(x => new DropdownDTO
            {
                Id = x.Key,
                Desc = x.Value
            }).OrderBy(x => x.Desc);
            return Okk(data);
        }

        [HttpPost]
        public IActionResult GetLookupSelectData(DropdownLookupSelect select)
        {
            var data = _lookupBiz.GetByCategory(select.LookupType).Select(x => new DropdownDTO
            {
                Id = x.Id,
                Desc = x.Value
            }).OrderBy(x => x.Desc);
            return Okk(data);
        }
    }
}