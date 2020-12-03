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
    public class ConfigBiz : BaseBiz<config, configDTO>, IConfigBiz
    {
        IUnitOfWork _unitOfWork;
        public ConfigBiz(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
