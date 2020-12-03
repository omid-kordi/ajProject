using System;
using System.Collections.Generic;
using System.Text;
using ajWebSite.Common.DTOs.Common;
using ajWebSite.Common.Enums;
using ajWebSite.Core.Biz;
using ajWebSite.Core.Contracts.Entities;

namespace ajWebSite.Services.Contracts.Common
{
    public interface ILookupBiz: IBiz<LookupDTO>
    {
        List<LookupDTO> GetByCategory(LookupType category);

        PaginatedResult<LookupDTO> GetPaginated(LookupSearch search);
    }
}
