using ajWebSite.Common.Enums;
using ajWebSite.Core.Contracts.Entities;
using ajWebSite.Domain.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Domain.ajWebSite
{
    public class salon : StrongEntity
    {
        public string saloonName { get; set; }
        public string addressState { get; set; }
        public string addressCity { get; set; }
        public string addressDetails { get; set; }
        public string pstalCode { get; set; }
        public string salonPhone { get; set; }
        public string seriveses { get; set; }
        public string packages { get; set; }
        public string locationLat { get; set; }
        public string locationLan { get; set; }
        public saloonState? state { get; set; }


    }
}
