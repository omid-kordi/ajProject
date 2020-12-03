using ajWebSite.Common.DTOs.Security;
using ajWebSite.Common.Enums;
using ajWebSite.Common.Helpers;
using ajWebSite.Core.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Common.DTOs.ajWebSite
{
    public class salonDTO : StrongEntityDTO
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
        public string salonStateTitle { get; set; }
        public string managementBy { get; set; }
        public string stateTitle
        {
            get
            {
                return state.ToDescription();
            }
        }
    }
}
