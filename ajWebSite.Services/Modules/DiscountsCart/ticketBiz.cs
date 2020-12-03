using ajWebSite.Common.DTOs.ajWebSite;
using ajWebSite.Core.Biz;
using ajWebSite.Core.DataAccess;
using ajWebSite.Domain.ajWebSite;
using ajWebSite.Services.Contracts.ajWebSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ajWebSite.Services.Modules.ajWebSite
{
    public class TicketBiz : BaseBiz<ticket, ticketDTO>, IticketBiz
    {
        public TicketBiz(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<ticketDTO> getBySessionId(string sessionId)
        {
            var resultMessages = Get(p => p.sessionID == sessionId);
            return ToDTOList(resultMessages);
        }

        public List<ticketGroupDTO> getTicketDiscotions()
        {
            var result=this.Get().GroupBy(p => new { p.title, p.sessionID }).Select(p => new ticketGroupDTO()
            {
                sessionId = p.Key.sessionID,
                title = p.Key.title,
                lastMessageCreationDateTime = p.Max(p => p.DateInserted)
            }).OrderByDescending(p => p.lastMessageCreationDateTime).ToList();
            return result;
        }
    }
}
