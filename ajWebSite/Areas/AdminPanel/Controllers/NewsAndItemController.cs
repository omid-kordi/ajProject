using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ajWebSite.Common.DTOs.Common;
using ajWebSite.Services.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ajWebSite.Areas.AdminPanel.Controllers
{
    [Authorize]
    [Route("AdminPanel/[Controller]/[Action]/{id?}")]
    public class NewsAndItemController : Controller
    {

        INewsAndItemBiz _newsAndItemBiz;
        public NewsAndItemController(INewsAndItemBiz newsAndItemBiz)
        {
            _newsAndItemBiz = newsAndItemBiz;
        }
        [HttpPost]
        public ActionResult createNewItem([FromForm]newsAndItemDTO item)
        { 
            var result=_newsAndItemBiz.InsertAndReturn(item);
            return Ok(Content(JsonConvert.SerializeObject(result)));
        }
        [HttpPost]
        public ActionResult updateNewsAndItem([FromForm] newsAndItemDTO item)
        {
            try
            {

                _newsAndItemBiz.Update(item);
                return Ok(Content(JsonConvert.SerializeObject(true)));
            }
            catch (Exception)
            {

                return Ok(Content(JsonConvert.SerializeObject(false)));
            }
        }
        public ActionResult Index()
        {
            return View("~/Areas/AdminPanel/Views/NewsAndItem/Index.cshtml");
        }
        public ActionResult getItem(int id)
        {
            var selectedItem =_newsAndItemBiz.GetByPK(id);
            return Ok(selectedItem);
        }
        public ActionResult getItems()
        {
            var items = _newsAndItemBiz.GetAll();
            return Ok(items);
        }
    }
}
