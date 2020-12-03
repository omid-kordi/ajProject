using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ajWebSite.Core.Contracts.DTOs;

namespace ajWebSite.Common.DTOs.Common
{
    public class TextMessageDTO : StrongEntityDTO
    {
        public string Message { get; set; }


        public string Mobile { get; set; }
        public string Result { get; set; }
    }
}
