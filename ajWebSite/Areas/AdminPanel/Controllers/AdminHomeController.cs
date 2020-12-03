using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ajWebSite.Common.DTOs.Common;
using ajWebSite.Core.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ajWebSite.Areas.AdminPanel.Controllers
{
    [AllowAnonymous]
    [Route("AdminPanel/[Controller]/[Action]")]
    public class AdminHomeController:Controller
    {
        private currentConfig _config;
        public AdminHomeController(currentConfig config)
        {
            _config = config;
        }
        public ActionResult Index()
        {
            return View("~/Areas/AdminPanel/Views/AdminHome/Index.cshtml");
        }
        public ActionResult siteConfig()
        {

            return View("~/Areas/AdminPanel/Views/AdminHome/siteConfig.cshtml");
        }
        public ActionResult getSiteSettings()
        {
            return new JsonResult(_config.configs);
        }
        public ActionResult saveSiteSettings(SiteConfig model)
        {
            model.copyItemsWithSuchNames(_config.configs);
            _config.saveConfigs();
            return Content("true");
        }
    }
}
