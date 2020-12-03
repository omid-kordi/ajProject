using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ajWebSite.Common.Enums;
using ajWebSite.Core.Contracts.Entities;

namespace ajWebSite.Domain.Common
{
    public class Payment: StrongEntity
    {
        public PaymentType Type { get; set; }

        public long Amount { get; set; }

        public bool Approved { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(100)]
        public string DigitalReceipt { get; set; }
        [StringLength(20)]
        public string CardNumber { get; set; }
        [StringLength(20)]
        public string TerminalNumber { get; set; }
        [StringLength(20)]
        public string RefNumber { get; set; }
        [StringLength(20)]
        public string TrackingCode { get; set; }

    }
}
