using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ajWebSite.Core.Contracts.Entities;

namespace ajWebSite.Domain.Security
{
    public class Access : StrongEntity
    {
        [StringLength(100)]
        public string Name { get; set; }
    }
}
