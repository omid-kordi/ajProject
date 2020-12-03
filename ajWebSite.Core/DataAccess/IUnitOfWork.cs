using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ajWebSite.Core.Contracts.Entities;
using ajWebSite.Core.Module;

namespace ajWebSite.Core.DataAccess
{
	public interface IUnitOfWork : IDisposable
	{

		IRepository<T> Repository<T>() where T : BaseEntity;

        string GetConnStr();
        DbContext GetContext();
        CurrentUser GetCurrentUser();
        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Commit();
	}
}
