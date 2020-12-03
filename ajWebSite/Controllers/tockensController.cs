using ajWebSite.Models.ticket;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ajWebSite.Common.DTOs.ajWebSite;
using ajWebSite.Common.Enums;
using ajWebSite.Core.Module;
using ajWebSite.Domain.ajWebSite;
using ajWebSite.Services.Contracts.ajWebSite;
using ajWebSite.Services.Contracts.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ajWebSite.Controllers
{
    public class tockensController : Controller
    {
        private IticketBiz _ticketBiz;
        IUserBiz _userBiz;
        CurrentUser _currentUser;
        private readonly ILogger<HomeController> _logger;

        public tockensController(ILogger<HomeController> logger, IticketBiz ticketBiz,IUserBiz userBiz, CurrentUser currentUser)
        {
            _logger = logger;
            _ticketBiz = ticketBiz;
            _userBiz = userBiz;
            _currentUser = currentUser;
        }
        public IActionResult Index()
        {
            return View(); 
        } 
        public IActionResult createNewTicket(createNewTicketModel model)
        {
            var adminOfWebSite=_userBiz.getAdminOfWebSite();
            int? senderUserId = null;
            if (_currentUser.IsAuthenticated==true)
            {
                senderUserId = _currentUser.ID;
            }
            var newTicket = new ticketDTO()
            {
                messageText = model.description,
                serverityLevel = (ServerityType)(model.serverity),
                title = model.title,
                sessionID=Guid.NewGuid().ToString(),
                RecieverId=adminOfWebSite.Id,
                emailAddress=model.emailAddress

            };
            try
            {
                _ticketBiz.Insert(newTicket);
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index");
        }
    }
}
