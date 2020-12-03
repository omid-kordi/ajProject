using System;
using System.Collections.Generic;
using System.Text;
using ajWebSite.Core.Contracts.Entities;

namespace ajWebSite.Domain.Security
{
    public class UserAccess : StrongEntity
    {
        public int UserId { get; set; }
        public int AccessId { get; set; }
        public User User { get; set; }
        public Access Access { get; set; }
    }
}
