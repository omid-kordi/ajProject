using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ajWebSite.Core.Contracts.Entities;

namespace ajWebSite.Domain.Common
{
    public class PersonDoc:StrongEntity
    {
        public int PersonId { get; set; }
        public int FileTypeId { get; set; }

        //hard to use guid on Oracle
        [StringLength(40)]
        public string FileBinaryUId { get; set; }

        public Person Person { get; set; }
        public Lookup FileType { get; set; }
    }
}
