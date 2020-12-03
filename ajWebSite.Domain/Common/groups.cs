using ajWebSite.Common.Enums;
using ajWebSite.Core.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Domain.Common
{
    public class Group : StrongEntity
    {
        public string title { get; set; }
        public int? parentId { get; set; }
        public Group parent { get; set; }
        public GroupType groupType { get; set; }

    }
}
