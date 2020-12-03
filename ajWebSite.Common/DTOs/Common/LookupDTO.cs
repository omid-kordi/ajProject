using System;
using System.Collections.Generic;
using System.Text;
using ajWebSite.Common.Enums;
using ajWebSite.Common.Helpers;
using ajWebSite.Core.Contracts.DTOs;
using ajWebSite.Core.Contracts.Entities;

namespace ajWebSite.Common.DTOs.Common
{
    public class LookupDTO : StrongEntityDTO
    {
        public LookupType Type { get; set; }
        public string Value { get; set; }


        public string TypeDesc => Type.ToDescription();
    }

    public class LookupSearch : BaseSearch
    {
        public LookupType? Type { get; set; }

    }
}
