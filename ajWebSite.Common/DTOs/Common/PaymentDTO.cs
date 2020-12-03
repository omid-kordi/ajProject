using System;
using System.Collections.Generic;
using System.Text;
using ajWebSite.Common.Enums;
using ajWebSite.Core.Contracts.DTOs;

namespace ajWebSite.Common.DTOs.Common
{
    public class PaymentDTO : StrongEntityDTO
    {
        public PaymentType Type { get; set; }

        public long Amount { get; set; }

        public bool Approved { get; set; }

        public string Desc { get; set; }
    }
}
