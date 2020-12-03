using ajWebSite.Areas.AdminPanel.Models.Admin;
using Microsoft.AspNetCore.Authorization;
 
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ajWebSite.Areas.AdminPanel.Controllers
{
    [AllowAnonymous]
    [Route("AdminPanel/[Controller]/[Action]")]
    public class AdminController:Controller
    {
        public ActionResult siteOwner()
        { 
            return View("~/Areas/AdminPanel/Views/Admin/siteOwner.cshtml");
        }
        public ActionResult siteAdmins(siteAdmins model)
        {

            return View("~/Areas/AdminPanel/Views/Admin/siteAdmins.cshtml",model);
        }
    }
}
