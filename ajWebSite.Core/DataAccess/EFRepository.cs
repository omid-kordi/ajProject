using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ajWebSite.Core.Contracts.Entities;
using ajWebSite.Core.Module;

namespace ajWebSite.Core.DataAccess
{
    public class EFRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        protected DbSet<T> Entities { get; private set; }
        private CurrentUser _currentUser { get; set; }
        private bool _checkTenant;


        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public EFRepository(DbContext context, CurrentUser currentUser)
        {
            this._context = context;
            this.Entities = _context.Set<T>(); 
            this._currentUser = currentUser;

            //if (currentUser.IsAuthenticated)
            //{
            //    _checkTenant = !typeof(T).IsSubclassOf(typeof(StrongEntityNoTenant));
            //}
        }

        public virtual IQueryable<T> Table => _context.Set<T>();
        public virtual IQueryable<T> TableNoTracking => this.Entities.AsNoTracking();

        public T GetByPK(params object[] keyValues)
        {
            var entity = Entities.Find(keyValues);
            //if (entity != null && entity.TenantId != _currentUser.TenantId && _checkTenant)
            //{
            //    throw new Exception("No Access to other tenant");
            //}
            return entity;
        }

        public IQueryable<T> GetByPKQueryable(params object[] keyValues)
        {
            var keyNames = _context.Model.FindEntityType(typeof(T))
                .FindPrimaryKey()
                .Properties
                .Select(x => x.Name).ToArray();
            var sql = $"select * from {GetSchemaAndTableName()} where ";
            for (int i = 0; i < keyNames.Length; i++)
            {
                sql += $" {(i > 0 ? "AND" : "")} {keyNames[i]} = {keyValues[i]} ";
            }

            return _context.Set<T>().FromSql(sql);
        }

        //public T GetByUId(Guid id)
        //{
        //    var entity = Entities.SingleOrDefault(x => x.UId == id);
        //    return entity;
        //}

        public virtual void Insert(T entity)
        {
            //var baseEnt = entity as BaseEntity;

            if (entity != null)
            {
                entity.DateInserted = DateTime.Now;
                entity.CreatorId = _currentUser.ID;
                //entity.TenantId = _currentUser.TenantId;
            }

            this.Entities.Add(entity);
        }


        public virtual void Update(T entity)
        {

            //var local = _context.Set<T>().Local.FirstOrDefault(e => e == entity);
            //if (local != null)
            //{
            //    _context.Entry(local).State = EntityState.Detached;
            //}
            //if (_context.Set<T>().Local.Any())
            //{
            //    var local = _context.Set<T>().Local.FirstOrDefault(x =>x.UId == entity.UId);
            //    if (local != null)
            //    {
            //        _context.Entry(local).State = EntityState.Detached;
            //    }
            //}
            

            entity.UpdaterId = _currentUser.ID;
            entity.DateModified = DateTime.Now;
            this.Entities.Update(entity);
        }


        public virtual void Delete(T entity)
        {
            entity.IsDelete = true;
            Update(entity);
        }

        public virtual void HardDelete(T entity)
        {
            //if (_context.Entry(entity).State == EntityState.Detached)
            //{
            //    ReAttach(entity);
            //    //this.Entities.Attach(entity);
            //}
            //if (entity.TenantId != _currentUser.TenantId && _checkTenant)
            //{
            //    throw new Exception("No Access to other tenant");
            //}


            this.Entities.Remove(entity);
        }

        public void DeleteByPK(params object[] keyValues)
        {
            var entityToDelete = Entities.Find(keyValues);
            Delete(entityToDelete);
        }

        public List<T> GetAll()
        {
            var query = Entities.Where(x => !x.IsDelete);
            return query.ToList();
            //if (_checkTenant)
            //{
            //    return query.Where(x => x.TenantId == _currentUser.TenantId).ToList();
            //}
            //else
            //{
            //    return query.ToList();
            //}
        }

        //public List<T> GetAllByAccess()
        //{
        //    return GetByAccess().ToList();
        //}

        //public IIncludableQueryable<T> Include(Expression<Func<T, TProperty>> navigationPropertyPath)

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, bool includeDeleted = false)
        {
            IQueryable<T> query = Entities;

            if (!includeDeleted)
            {
                query = query.Where(x => !x.IsDelete);
            }


            if (filter != null)
            {
                query = query.Where(filter);
            }

            //if (_checkTenant)
            //{
            //    query = query.Where(x => x.TenantId == _currentUser.TenantId);
            //}


            return query;//.AsNoTracking();
        }


        public PaginatedResult<T> QueryPaginated(PaginatedRequest request, IQueryable<T> query = null)
        {
            if (query == null)
                query = this.Entities.AsQueryable();
            //if (_checkTenant)
            //{
            //    query = query.Where(x => x.TenantId == _currentUser.TenantId);
            //}
            var dsResult = query.OrderByDescending(x => x.DateInserted).ToPaginatedResult(request);
            return dsResult;
        }


        public void DeleteRange(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = Entities.Where(filter);
            //if (_checkTenant)
            //{
            //    query = query.Where(x => x.TenantId == _currentUser.TenantId);
            //}
            _context.Set<T>().RemoveRange(query);
        }


        //public virtual object GetKey<T>(T entity,out string keyName)
        //{
        //    keyName = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties
        //        .Select(x => x.Name).Single();

        //    return entity.GetType().GetProperty(keyName).GetValue(entity, null);
        //}


        //public IQueryable<T> GetByAccess(Expression<Func<T, bool>> filter = null)
        //{
        //    if (_currentUser.IsAdmin)
        //    {
        //        return Get(filter);
        //    }

        //    var entity = typeof(T).Name;
        //    var userId = _currentUser.ID;
        //    var chartId = _currentUser.ChartId;
        //    var mapping = _context.Model.FindEntityType(typeof(T)).Relational();
        //    var schema = mapping.Schema;
        //    var tableName = mapping.TableName;
        //    var key = entity + "ID";
        //    var accessMatrixQuery = $@"
        //        SELECT um.MatrixValue  from [Common].[ums].[UserAccessMatrix] um
        //        where um.EntityName = '{entity}' and um.LocalUserId = {userId}
        //        union 
        //        SELECT cm.MatrixValue  from [Common].[ums].[ChartAccessMatrix] cm
        //        where cm.EntityName = '{entity}' and cm.LocalChartId = {chartId}
        //        union 
        //        SELECT rm.MatrixValue  from [Common].[ums].[RoleAccessMatrix] rm
        //        inner join [Common].[ums].[UserRole] ur on ur.localRoleID = rm.localRoleID
        //        where rm.EntityName = '{entity}' and ur.LocalUserId = {userId}";
        //    var sql = $@"select * from {schema}.{tableName} where {key} in ({accessMatrixQuery})";

        //    IQueryable<T> query = _context.Set<T>().FromSql(sql).AsNoTracking();


        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }

        //    return query;
        //}


        public string GetSchemaAndTableName()
        {
            var mapping = _context.Model.FindEntityType(typeof(T)).Relational();
            var schema = mapping.Schema ?? "dbo";
            var tableName = mapping.TableName;
            return $"{schema}.{tableName}";
        }






    }
}
