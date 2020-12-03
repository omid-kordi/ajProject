using ajWebSite.Common.Enums;
using ajWebSite.Core.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Domain.Common
{
    public class config : StrongEntity
    {
        public string configName { get; set; }
        public string configValue { get; set; }
    }
}
