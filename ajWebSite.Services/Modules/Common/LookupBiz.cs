using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ajWebSite.Common.DTOs.Common;
using ajWebSite.Common.Enums;
using ajWebSite.Core.Biz;
using ajWebSite.Core.Contracts.Entities;
using ajWebSite.Core.DataAccess;
using ajWebSite.Core.Module;
using ajWebSite.Domain.Common;
using ajWebSite.Services.Contracts.Common;

namespace ajWebSite.Services.Modules.Common
{
    public class LookupBiz:BaseBiz<Lookup,LookupDTO>, ILookupBiz
    {
        public LookupBiz(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<LookupDTO> GetByCategory(LookupType category)
        {
            var data = UnitOfWork.Repository<Lookup>().Get(x => x.Type == category);
            return ToDTOList(data);
        }

        public PaginatedResult<LookupDTO> GetPaginated(LookupSearch search)
        {
            var data = UnitOfWork.Repository<Lookup>().Get();

            if (search.Type.HasValue)
                data = data.Where(x => x.Type == search.Type);

            return GetPaginated(search, data);
        }
    }
}
