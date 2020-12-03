using System;
using System.Collections.Generic;
using System.Text;
using ajWebSite.Common.DTOs.Common;
using ajWebSite.Core.Biz;
using ajWebSite.Core.DataAccess;
using ajWebSite.Domain.Common;
using ajWebSite.Services.Contracts.Common;

namespace ajWebSite.Services.Modules.Common
{
  public class ParkingBiz : BaseBiz<Parking,ParkingDTO>, IParkingBiz
    {
        public ParkingBiz(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
