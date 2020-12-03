using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ajWebSite.Common.Enums;
using ajWebSite.Core.Contracts.Entities;

namespace ajWebSite.Domain.Common
{
    public class Lookup : StrongEntity
    {
        public LookupType Type { get; set; }
        
        [StringLength(100)]
        public string Value { get; set; }
    }
}
