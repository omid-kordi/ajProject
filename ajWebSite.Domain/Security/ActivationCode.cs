using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ajWebSite.Core.Contracts.Entities;

namespace ajWebSite.Domain.Security
{
    public class ActivationCode:StrongEntity
    {
        [StringLength(5)]
        public string Code { get; set; }
        
        [StringLength(15)]
        public string Mobile { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}
