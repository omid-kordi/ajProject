using ajWebSite.Areas.AdminPanel.Models.ticket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ajWebSite.Common.DTOs.ajWebSite;
using ajWebSite.Core.Module;
using ajWebSite.Services.Contracts.ajWebSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ajWebSite.Areas.AdminPanel.Controllers
{
    [Authorize]
    [Route("AdminPanel/[Controller]/[Action]")]
    public class ticketController:Controller
    {
        IticketBiz _ticketBiz;
        CurrentUser _currentUser;
        public ticketController(IticketBiz ticketBiz, CurrentUser currentUser)
        {
            _ticketBiz = ticketBiz;
            _currentUser = currentUser;
        }
        public ActionResult Index()
        {
            var model = new ticketIndexModel();
            model.ticketGroups = _ticketBiz.getTicketDiscotions();
            return View("~/Areas/AdminPanel/Views/ticket/Index.cshtml", model);
        }
        public ActionResult getSessionsOfChannel() {
            var resultModel =_ticketBiz.getTicketDiscotions();
            return new JsonResult(resultModel);
        }
        public ActionResult addMessage(ticketDTO messageModel)
        {
            if (messageModel.RecieverId==0)
            {
                messageModel.RecieverId = null; 
            }
            messageModel.CreatorId = _currentUser.ID;
            messageModel.SenderId = _currentUser.ID;
            var returnedItem = _ticketBiz.InsertAndReturn(messageModel);
            return new JsonResult(returnedItem);
        }
        [HttpGet("{sessionID}")]
        public ActionResult getMessageOfSession(string sessionID)
        {
            
            var messages = _ticketBiz.getBySessionId(sessionID);
            return new JsonResult(messages);

        }
    }
}
