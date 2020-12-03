using System;
using System.Collections.Generic;
using System.Text;
using ajWebSite.Core.Contracts.DTOs;

namespace ajWebSite.Common.DTOs.Common
{
    public class PersonDTO : StrongEntityDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
    }
}
