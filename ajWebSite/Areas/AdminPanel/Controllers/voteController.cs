using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ajWebSite.Common.DTOs.Common;
using ajWebSite.Common.Enums;
using ajWebSite.Core.Module;
using ajWebSite.Services.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ajWebSite.Areas.AdminPanel.Controllers
{
    [AllowAnonymous]
    [Route("AdminPanel/[Controller]/[Action]/{id?}/{id2?}")]
    public class voteController : Controller
    {
        private IVoteBiz _ivoteBiz;
        CurrentUser _currentUser;
        public voteController(IVoteBiz ivoteBiz, CurrentUser currentUser)
        {
            _ivoteBiz = ivoteBiz;
            _currentUser = currentUser;
        }
        public ActionResult getVotes(int id, int id2, VoteOwnerType voteOwnerType,int? newVoteValue)
        {
            if (newVoteValue!=null)
            {
                var newVoteObject = new voteDTO()
                {
                    ownerID = id,
                    partParam = (int)voteOwnerType,
                    secondPartParam = id2,
                    value = newVoteValue??0
                };
                _ivoteBiz.InsertAndReturn(newVoteObject);
            }
             var result = _ivoteBiz.getVotes(id, (int)voteOwnerType, id2);
            var countOfVots = result.Count()*5;
            var averageOfVotes =Convert.ToInt32(Math.Floor(result.Select(p => p.value).Sum() / countOfVots * 5));
            return View("~/Areas/AdminPanel/Views/vote/getVotes.cshtml", averageOfVotes);
        }
        public ActionResult addvote(voteDTO model)
        {
            var result = _ivoteBiz.InsertAndReturn(model);
            return new JsonResult(result);
        }
        public ActionResult deleteVote(int id)
        {
            try
            {
                var selectedItem = _ivoteBiz.GetByPK(new { Id = id });
                if (selectedItem != null)
                {
                    selectedItem.IsDelete = true;
                    _ivoteBiz.Update(selectedItem, true);
                }
                return new JsonResult(true);
            }
            catch (Exception)
            {
                return new JsonResult(false);

            }
        }

    }
}
