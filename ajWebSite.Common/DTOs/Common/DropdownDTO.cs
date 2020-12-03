using System;
using System.Collections.Generic;
using System.Text;
using ajWebSite.Common.Enums;

namespace ajWebSite.Common.DTOs.Common
{
    public class DropdownDTO
    {
        public int Id { get; set; }
        public string Desc { get; set; }
    }

    public class DropdownEnumSelect
    {
        public string EnumType { get; set; }
    }

    public class DropdownLookupSelect
    {
        public LookupType LookupType { get; set; }
    }
}
