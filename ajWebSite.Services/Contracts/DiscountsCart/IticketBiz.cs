using ajWebSite.Common.DTOs.ajWebSite;
using ajWebSite.Core.Biz;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Services.Contracts.ajWebSite
{
    public interface IticketBiz : IBiz<ticketDTO>
    {
        List<ticketGroupDTO> getTicketDiscotions();
        List<ticketDTO> getBySessionId(string sessionId);
    }
}
