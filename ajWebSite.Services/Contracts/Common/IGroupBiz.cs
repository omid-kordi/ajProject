using ajWebSite.Common.DTOs.Common;
using ajWebSite.Common.Enums;
using ajWebSite.Core.Biz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ajWebSite.Services.Contracts.Common
{
    public interface IGroupBiz : IBiz<GroupDTO>
    {
        public GroupDTO getGroupsrootNode(GroupType type);
        public List<GroupDTO> getChildsOfItem(GroupType type,int itemId);
    }
}
