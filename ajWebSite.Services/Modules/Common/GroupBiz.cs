using ajWebSite.Common.DTOs.Common;
using ajWebSite.Common.Enums;
using ajWebSite.Core.Biz;
using ajWebSite.Core.DataAccess;
using ajWebSite.Core.Module;
using ajWebSite.Domain.Common;
using ajWebSite.Services.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace ajWebSite.Services.Modules.Common
{
    public class GroupBiz : BaseBiz<Group, GroupDTO>, IGroupBiz
    {
        IUnitOfWork _unitOfWork;
        public GroupBiz(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<GroupDTO> getChildsOfItem(GroupType type, int itemId)
        {
            var rep = _unitOfWork.Repository<Group>();
            var childItems = rep.Get(p => p.groupType == type && p.parentId == itemId);
            if (childItems == null)
            {
                throw new Exception("این گروه خالی می باشد");
            } 
            return childItems.ToDTOList<GroupDTO>();
        }
         

        public GroupDTO getGroupsrootNode(GroupType type)
        {
            var rep = _unitOfWork.Repository<Group>();
            var rootItem=rep.Get(p => p.groupType == type && p.parentId == null).FirstOrDefault();
            if (rootItem==null)
            {
                throw new Exception("این گروه خالی می باشد");
            }
            var rootItemDTO = new GroupDTO()
            {
                Id=rootItem.Id,
                parentId=rootItem.parentId,
                CreatorId=rootItem.CreatorId??0,
                UpdaterId=rootItem.UpdaterId,
                title=rootItem.title,
                IsDelete=rootItem.IsDelete,
                DateInserted=rootItem.DateInserted,
                DateModified=rootItem.DateModified,
                groupType=rootItem.groupType
            };
            return rootItemDTO;
        } 
    }
}
