using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ajWebSite.Common.DTOs.Common;
using ajWebSite.Core.Biz;
using ajWebSite.Core.DataAccess;
using ajWebSite.Core.Module;
using ajWebSite.Domain.Common;
using ajWebSite.Domain.Security;
using ajWebSite.Services.Contracts.Common;

namespace ajWebSite.Services.Modules.Common
{
    public class PersonBiz:BaseBiz<Person,PersonDTO>, IPersonBiz
    {
        public PersonBiz(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void AddDetail(PersonDetailDTO detail)
        {
            var old = UnitOfWork.Repository<PersonDetail>().Get(x => x.PersonId == detail.PersonId).FirstOrDefault();
            if (old != null)
            {
                old.IsDelete = true;
                UnitOfWork.Repository<PersonDetail>().Update(old);
            }

            var user = UnitOfWork.Repository<User>().GetByPK(detail.UserId);
            user.IsFullRegistered = true;

            UnitOfWork.Repository<PersonDetail>().Insert(detail.ToEntity<PersonDetail>());
            UnitOfWork.Repository<User>().Update(user);
            UnitOfWork.Commit();
        }

        public PersonDetailDTO GetDetail(int personId)
        {
            var data = UnitOfWork.Repository<PersonDetail>().Get(x => x.PersonId == personId).FirstOrDefault();
            return data.ToDTO<PersonDetailDTO>();
        }

        public void AddDoc(PersonDocDTO doc)
        {
            UnitOfWork.Repository<PersonDoc>().Insert(doc.ToEntity<PersonDoc>());
            UnitOfWork.Commit();
        }

        public List<PersonDocDTO> GetDocs(int personId)
        {
            var data = UnitOfWork.Repository<PersonDoc>().Get(p => p.PersonId == personId);
            return data.ToDTOList<PersonDocDTO>();
        }
    }
}
