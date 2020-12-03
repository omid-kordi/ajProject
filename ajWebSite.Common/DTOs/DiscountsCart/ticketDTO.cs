using ajWebSite.Common.Enums;
using ajWebSite.Core.Contracts.DTOs;
using ajWebSite.Core.Module;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Common.DTOs.ajWebSite
{
    public class ticketDTO : StrongEntityDTO
    { 
        public string sessionID { get; set; }
        public string messageText { get; set; }
        public string attachmentUrl { get; set; }
        public string title { get; set; }
        public ServerityType? serverityLevel { get; set; }
        public int? SenderId { get; set; }
        public string senderName { get; set; }
        public int? RecieverId { get; set; }
        public string RecieverName { get; set; }
        public string messageTitle { get; set; }
        public string emailAddress { get; set; }
        public string persianDateTimeInserted
        {
            get
            {
                return this.DateInserted.getPersian();
            }
        }
    }
    public class ticketGroupDTO
    {
        public string sessionId { get; set; }
        public string title { get; set; }
        public string kind { get; set; }
        public DateTime lastMessageCreationDateTime { get; set; }
    }
}
