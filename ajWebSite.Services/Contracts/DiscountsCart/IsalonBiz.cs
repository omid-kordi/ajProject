using ajWebSite.Common.DTOs.ajWebSite;
using ajWebSite.Common.Enums;
using ajWebSite.Core.Biz;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Services.Contracts.ajWebSite
{
    public interface IsalonBiz : IBiz<salonDTO>
    {
        void changeSalonState(int salonId, saloonState newState);
    }
}
