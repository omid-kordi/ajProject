using ajWebSite.Core.Contracts.DTOs;
using ajWebSite.Core.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Common.DTOs.Common
{
    public class voteDTO : StrongEntityDTO
    { 
        public float value { get; set; }
        public int ownerID { get; set; }
        public int partParam { get; set; }
        public int secondPartParam { get; set; }
    }
}
