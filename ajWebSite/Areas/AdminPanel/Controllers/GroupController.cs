using ajWebSite.Areas.AdminPanel.Models.Group;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ajWebSite.Common.DTOs.Common;
using ajWebSite.Common.Enums;
using ajWebSite.Services.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ajWebSite.Areas.AdminPanel.Controllers
{
    [Authorize]
    [Route("AdminPanel/[Controller]/[Action]/{id}")]
    public class GroupController : Controller
    {

        IGroupBiz _groupBiz;
        public GroupController(IGroupBiz groupBiz)
        {
            _groupBiz = groupBiz;
        }
        public ActionResult Index()
        {
            return View("~/Areas/AdminPanel/Views/Group/Index.cshtml");
        }
        public ActionResult getGroupsByTreeViewierarchyOfNewsAnditem(string id)
        {
            List<groupNode> result = new List<groupNode>();
            var selectedNodeId = int.Parse(id);
            var rootNode = _groupBiz.getGroupsrootNode((GroupType)1);
            groupNode tempItem = new groupNode()
            {
                id = rootNode.Id,
                state = "closed",
                text = rootNode.title
            };
            fillChilds(tempItem, GroupType.newsArticleGroup);
            result.Add(tempItem);
            return Content(JsonConvert.SerializeObject(result,
                      Newtonsoft.Json.Formatting.Indented,
                      new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }

        private void fillChilds(groupNode node, GroupType groupType)
        {
            var childs = _groupBiz.getChildsOfItem(groupType, node.id);
            if (childs == null || childs.Count() < 1)
            { 
                node.state = null;
                node.children = null;
                return;
            }
            foreach (var item in childs)
            {
                groupNode tempItem = new groupNode()
                {
                    id = item.Id,
                    state = "closed",
                    text = item.title
                };
                node.children.Add(tempItem);
                fillChilds(tempItem, groupType);
            }
            return;
        }
    }
}
