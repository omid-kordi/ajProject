using ajWebSite.Common.DTOs.Common;
using ajWebSite.Core.Biz;
using ajWebSite.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ajWebSite.Services.Contracts.Common
{
    public interface ICommentBiz : IBiz<commentDTO>
    {
        List<commentDTO> getComments(int id,int param1,int param2);
        List<commentDTO> getAllComments(searchCommentModel model);
    }
}
