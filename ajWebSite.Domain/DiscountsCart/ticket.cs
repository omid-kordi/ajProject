using ajWebSite.Common.Enums;
using ajWebSite.Core.Contracts.Entities;
using ajWebSite.Domain.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Domain.ajWebSite
{
    public class ticket: StrongEntity
    {

        public string  sessionID { get; set; }
        public string messageText { get; set; }
        public string attachmentUrl { get; set; }
        public string title { get; set; }
        public ServerityType serverityLevel { get; set; }
        public string  messageTitle { get; set; }
        public int? SenderId { get; set; }
        public User? Sender { get; set; }
        public int? RecieverId { get; set; }
        public User? Reciever { get; set; }
        public string emailAddress { get; set; }
    }
}
