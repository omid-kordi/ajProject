using ajWebSite.Common.Enums;
using ajWebSite.Core.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ajWebSite.Domain.Common
{
    public class comment : StrongEntity
    { 
        public string commentText { get; set; }
        public int ownerID { get; set; }
        public int partParam { get; set; }
        public int secondPartParam { get; set; }
        public Boolean? isValid { get; set; }
        public int? parentId { get; set; }
        public comment parent { get; set; }
        public commentType? commentType { get; set; }
        public List<comment> childComments { get; set; }

    }
}
