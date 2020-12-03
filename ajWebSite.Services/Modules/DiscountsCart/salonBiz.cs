using ajWebSite.Common.DTOs.ajWebSite;
using ajWebSite.Common.Enums;
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
    public class salonBiz : BaseBiz<salon, salonDTO>, IsalonBiz
    {
        IUnitOfWork _unitOfWork;
        public salonBiz(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void changeSalonState(int salonId, saloonState newState)
        {
            var selectedSalon = Get(p => p.Id == salonId).FirstOrDefault();
            if (selectedSalon==null)
            {
                throw new Exception("سالن مورد نظر پیدا نشد");
            }
            selectedSalon.state = newState;
            var rep = UnitOfWork.Repository<salon>();
            rep.Update(selectedSalon);
            UnitOfWork.Commit();
        }
    }
}
