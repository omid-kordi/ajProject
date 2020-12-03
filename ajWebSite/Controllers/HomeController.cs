using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ajWebSite.Models;
using ajWebSite.Core.Module;

namespace ajWebSite.Controllers
{
    public class HomeController : Controller
    {
        private currentConfig _config;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, currentConfig config)
        {
            _config = config;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult testConfig()
        {
            _config.configs.AdminEmailAddress = "isadseta@gmail.com";
            _config.saveConfigs();
            return Content("True");

        }

    }
}
