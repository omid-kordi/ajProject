using ajWebSite.Common.DTOs.Common;
using ajWebSite.Core.Biz;
using ajWebSite.Core.Contracts.Entities;
using ajWebSite.Core.DataAccess;
using ajWebSite.Domain.Common;
using ajWebSite.Domain.Security;
using ajWebSite.Services.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using static Dapper.SqlMapper;

namespace ajWebSite.Services.Modules.Common
{
    public class CommentBiz : BaseBiz<comment, commentDTO>, ICommentBiz
    {
        IUnitOfWork _unitOfWork;
        public CommentBiz(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<commentDTO> getAllComments(searchCommentModel model)
        { 
            var result = Get(p=>p.Id>0,true);
            if (model.commentText.Length>0)
            {
                result = result.Where(p => p.commentText.Contains(model.commentText));
            }
            if (model.userName.Length > 0)
            {

                var users = _unitOfWork.Repository<User>().Get(p => p.Username.Contains(model.userName)).Select(p=>p.Id).ToList();
                if (users.Count()>0)
                {
                    result = result.Where(p => users.Contains(p.CreatorId??0)); 
                }
            }
            if (model.withDeleted!=null && model.withDeleted==true)
            {
                result = result.Where(p => p.IsDelete==true); 
            }
            return ToDTOList(result);
        }

        public List<commentDTO> getComments(int id, int param1, int param2)
        {
            var commentList = Get(p => (p.ownerID == id && p.partParam == param1 && p.secondPartParam == param2));
            return ToDTOList(commentList);
        }
    }
}
