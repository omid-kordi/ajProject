using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ajWebSite.Core.Contracts.Entities;

namespace ajWebSite.Domain.Common
{
    public class TextMessage : StrongEntity
    {
        [StringLength(500)]
        public string Message { get; set; }

        [StringLength(15)]
        public string Mobile { get; set; }

        [StringLength(100)]
        public string Result { get; set; }
    }
}
