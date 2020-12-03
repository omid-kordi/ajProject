using ajWebSite.Common.Enums;
using ajWebSite.Core.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Common.DTOs.Common
{
    public class GroupDTO : StrongEntityDTO
    {
        public string title { get; set; }
        public int? parentId { get; set; }
        public GroupDTO parent { get; set; }
        public GroupType groupType { get; set; }
        public List<GroupDTO> childs { get; set; }
    }
}
