using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ajWebSite.Common.DTOs;
using ajWebSite.Core.Biz;
using ajWebSite.Core.Contracts.Entities;

namespace ajWebSite.API.Controllers
{
    public class CRUDBaseApiController<TDTO> : BaseApiController
    {
        private IBiz<TDTO> _biz;
        public CRUDBaseApiController(IBiz<TDTO> biz)
        {
            this._biz = biz;
        }

        [HttpPost]
        public IActionResult Get(IdRequest req)
        {
            var data = _biz.GetByPK(req.Id);
            return Okk(data);
        }

        [HttpPost]
        public IActionResult Create(TDTO dto)
        {
            _biz.Insert(dto);
            return Okk();
        }

        [HttpPost]
        public IActionResult Update(TDTO dto)
        {
            _biz.Update(dto);
            return Okk();
        }

        [HttpPost]
        public IActionResult Delete(IdRequest req)
        {
            _biz.DeleteByPk(req.Id);
            return Okk();
        }
    }
}