using ajWebSite.Common.DTOs.Common;
using ajWebSite.Core.Biz;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Services.Contracts.Common
{
    public interface IVoteBiz : IBiz<voteDTO>
    {
        List<voteDTO> getVotes(int id, int param1, int param2);
    }
}
