using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ajWebSite.Common.Enums;
using ajWebSite.Core.Contracts.Entities;
using ajWebSite.Domain.Common;

namespace ajWebSite.Domain.Security
{
    public class User : StrongEntity
    {
        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        public DateTime? LastLoginDate { get; set; }
        public int NumberOfLoginAttempt { get; set; }
        public DateTime? LastLoginAttemptDate { get; set; }


        public UserType Type { get; set; }
        public bool IsFullRegistered { get; set; }

        public int? PersonId { get; set; }

        public int? CompanyId { get; set; } // for person type 2

        public Person Person { get; set; }
        public Lookup Company { get; set; }
        public string emailAddress { get; set; }
    }
}
