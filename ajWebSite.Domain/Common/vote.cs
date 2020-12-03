using ajWebSite.Core.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Domain.Common
{
    public class vote : StrongEntity
    { 
        public float value { get; set; }
        public int ownerID { get; set; }
        public int partParam { get; set; }
        public int secondPartParam { get; set; }
        public Boolean? isValid { get; set; }


    }
}
