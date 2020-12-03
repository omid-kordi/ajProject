using System;
using System.Collections.Generic;
using System.Text;
using ajWebSite.Core.Contracts.DTOs;

namespace ajWebSite.Common.DTOs.Common
{
    public class PersonDocDTO: StrongEntityDTO
    {
        public int PersonId { get; set; }
        public int FileTypeId { get; set; }

        public string FileBinaryUId { get; set; }
    }
}
