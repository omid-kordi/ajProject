using ajWebSite.Common.Enums;
using ajWebSite.Core.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Common.DTOs.Common
{
    public class configDTO : StrongEntityDTO
    {
        public string configName { get; set; }
        public string configValue { get; set; }
    }
}
