using ajWebSite.Core.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ajWebSite.Common.Enums;

namespace ajWebSite.Domain.Common
{
    public class Person : StrongEntity
    {
        public PersonType PersonType { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(15)]
        public string NationalCode { get; set; }
        [StringLength(15)]
        public string Mobile { get; set; }

        public ICollection<PersonDetail> Details { get; set; }
    }
}
