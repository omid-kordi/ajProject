using System;
using System.Collections.Generic;
using System.Text;
using ajWebSite.Common.DTOs.Common;
using ajWebSite.Core.Biz;

namespace ajWebSite.Services.Contracts.Common
{
    public interface IPersonBiz: IBiz<PersonDTO>
    {

        void AddDetail(PersonDetailDTO detail);
        PersonDetailDTO GetDetail(int personId);

        void AddDoc(PersonDocDTO doc);

        List<PersonDocDTO> GetDocs(int personId);
    }
}
