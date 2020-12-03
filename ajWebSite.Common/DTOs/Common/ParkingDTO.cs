using System;
using System.Collections.Generic;
using System.Text;
using ajWebSite.Core.Contracts.DTOs;

namespace ajWebSite.Common.DTOs.Common
{
    public class ParkingDTO : StrongEntityDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int TypeId { get; set; }

        public string TypeDesc { get; set; }
    }
}
