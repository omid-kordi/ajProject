using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ajWebSite.Common.DTOs.Common;
using ajWebSite.Common.Enums;
using ajWebSite.Domain.Common;
using ajWebSite.Services.Contracts.Common;
using ajWebSite.Services.Contracts.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ajWebSite.Areas.AdminPanel.Controllers
{
    [AllowAnonymous]
    [Route("AdminPanel/[Controller]/[Action]/{id?}/{id2?}")]
    public class commentController : BaseControllerClass
    {
        private IUserBiz _userBiz;
        private ICommentBiz _commentBiz;
        public commentController(ICommentBiz commentBiz, IUserBiz userBiz)
        {
            _userBiz = userBiz;
            _commentBiz = commentBiz;
        }
        public ActionResult Index()
        {
            return View("~/Areas/AdminPanel/Views/comment/Index.cshtml");
        }
        public ActionResult getComments(int id, int id2, CommentOwnerType commentOwnerType)
        {
            var result = _commentBiz.getComments(id, (int)commentOwnerType, id2).OrderByDescending(p=>p.DateInserted).ToList();
            foreach (var item in result)
            {
                if (item.ownerID > 0)
                {
                    var selectedUser = _userBiz.getUserById(item.ownerID );
                    if (selectedUser != null)
                    {
                        item.ownerUserName = selectedUser.Username;
                    }
                    else
                        item.ownerUserName = "کاربر ناشناس";

                }
            }
            return new JsonResult(result);
        }
        [HttpPost]
        public ActionResult addComment(commentDTO model)
        {
            var result = _commentBiz.InsertAndReturn(model);
            return new JsonResult(result);
        }
        public async Task<ActionResult> getFullComments(searchCommentModel model)
        {
            var result = await runTaskAsync<List<commentDTO>>(async () =>
            { 
                var resultData = _commentBiz.getAllComments(model);
                return resultData;
            });
            return Ok(result);
        }
        public ActionResult deleteComment(int id)
        {
            try
            {
                var selectedItem = _commentBiz.GetByPK(id);
                if (selectedItem != null)
                {
                    selectedItem.IsDelete = true;
                    _commentBiz.Update(selectedItem, true);
                }
                return new JsonResult(true);
            }
            catch (Exception ex)
            {
                return new JsonResult(false);

            }
        }
    }
}
