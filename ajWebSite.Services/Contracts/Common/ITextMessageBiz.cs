using System;
using System.Collections.Generic;
using System.Text;
using ajWebSite.Common.DTOs.Common;
using ajWebSite.Core.Biz;

namespace ajWebSite.Services.Contracts.Common
{
    public interface ITextMessageBiz:IBiz<TextMessageDTO>
    {
        bool Send(string phone, string message);
    }
}
