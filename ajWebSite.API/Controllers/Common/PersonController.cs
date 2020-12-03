using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ajWebSite.Common.DTOs.Common;
using ajWebSite.Core.Module;
using ajWebSite.Services.Contracts.Common;
using ajWebSite.Services.Contracts.Security;

namespace ajWebSite.API.Controllers.Common
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : BaseApiController
    {
        private IPersonBiz _personBiz;
        private CurrentUser _currentUser;
        public PersonController( CurrentUser currentUser, IPersonBiz personBiz)
        {
            _currentUser = currentUser;
            _personBiz = personBiz;
        }


        [HttpPost]
        public IActionResult GetDetail()
        {
            var data = _personBiz.GetDetail(_currentUser.PersonId);
            return Okk(data);
        }

        [HttpPost]
        public IActionResult AddDetail(PersonDetailDTO detail)
        {
            detail.PersonId = _currentUser.PersonId;
            detail.UserId = _currentUser.ID;
            _personBiz.AddDetail(detail);
            return Okk();
        }

        [HttpPost]
        public IActionResult GetDocs()
        {
            var data = _personBiz.GetDocs(_currentUser.PersonId);
            return Okk(data);
        }

        [HttpPost]
        public IActionResult AddDoc(PersonDocDTO doc)
        {
            doc.PersonId = _currentUser.PersonId;
            _personBiz.AddDoc(doc);
            return Okk();
        }

    }
}