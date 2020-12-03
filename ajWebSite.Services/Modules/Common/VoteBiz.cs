using ajWebSite.Common.DTOs.Common;
using ajWebSite.Core.Biz;
using ajWebSite.Core.DataAccess;
using ajWebSite.Domain.Common;
using ajWebSite.Services.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Services.Modules.Common
{
    public class VoteBiz : BaseBiz<vote, voteDTO>, IVoteBiz
    {
        IUnitOfWork _unitOfWork;
        public VoteBiz(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<voteDTO> getVotes(int id, int param1, int param2)
        {
            var commentList = Get(p => (p.ownerID == id && p.partParam == param1 && p.secondPartParam == param2));
            return ToDTOList(commentList);
        }

    }
}
