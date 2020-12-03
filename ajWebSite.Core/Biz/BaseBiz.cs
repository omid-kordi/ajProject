using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using ajWebSite.Core.Contracts.DTOs;
using ajWebSite.Core.Contracts.Entities;
using ajWebSite.Core.DataAccess;
using ajWebSite.Core.Module;

namespace ajWebSite.Core.Biz
{
    public class BaseBiz<TEntity, TDTO>
        where TEntity : BaseEntity
        where TDTO : BaseEntityDTO
    {
        const string DtoPostfix = "DTO";


        private IRepository<TEntity> _repository;
        protected IUnitOfWork UnitOfWork; 
        protected CurrentUser CurrentUser => UnitOfWork.GetCurrentUser();


        //protected byte[] GetbyteArray(HttpPostedFile file)
        //{
        //    byte[] fileData = null;
        //    using (var binaryReader = new BinaryReader(file.InputStream))
        //    {
        //        fileData = binaryReader.ReadBytes(file.ContentLength);
        //    }
        //    return fileData;
        //}
        public BaseBiz(IUnitOfWork unitOfWork )
        {
            this.UnitOfWork = unitOfWork;
            //this._repository = repository; 
            this._repository = unitOfWork.Repository<TEntity>();
        }

        public void Commit()
        {
            UnitOfWork.Commit();
        }


        public virtual List<TDTO> GetAll()
        {
            return _repository.Get().ToDTOList<TDTO>();
        }


        //public List<TDTO> GetAll<TProperty>(Expression<Func<TDTO, TProperty>>[] includeProperties = null)
        //{
        //    return Repository.GetAll<TEntity>(GetInclustionString(includeProperties)).ToDTOList<TDTO>();
        //}


        public virtual void DeleteByPk(params object[] keyValues)
        {
            _repository.DeleteByPK(keyValues);
            UnitOfWork.Commit();
        }

        public virtual void Delete(TDTO dto, bool commit = true)
        {
            _repository.Delete(dto.ToEntity<TEntity>());
            if (commit)
                UnitOfWork.Commit();
        }

        public virtual void DeleteRange(Expression<Func<TEntity, bool>> filter, bool commit = true)
        {
            _repository.DeleteRange(filter);
            if (commit)
                UnitOfWork.Commit();
        }

        public virtual TDTO GetByPK(params object[] keyValues)
        {
            //return _repository.GetByPK(keyValues).ToDTO<TDTO>();

            //To Use advantage of Mapper ProjectTo 
            return _repository.GetByPKQueryable(keyValues).AsNoTracking().ToDTOList<TDTO>().FirstOrDefault();
        }

        //public virtual TDTO GetByPKNoTracking(params object[] keyValues)
        //{
        //    //return _repository.GetByPK(keyValues).ToDTO<TDTO>();

        //    //To Use advantage of Mapper ProjectTo 
        //    return _repository.GetByPKQueryable(keyValues).AsNoTracking().ToDTOList<TDTO>().FirstOrDefault();
        //}

        //public virtual TDTO GetByUId(Guid id)
        //{
        //    return _repository.GetByUId(id).ToDTO<TDTO>();
        //}

        //public void DeleteByUId(Guid uId)
        //{
        //    _repository.DeleteByUId(uId);
        //    UnitOfWork.Commit();
        //}

        public virtual void Insert(TDTO newDto, bool commit = true)
        {
            var currentUser = UnitOfWork.GetCurrentUser();
            var entity = newDto.ToEntity<TEntity>();
            entity.DateInserted = DateTime.Now;
            entity.CreatorId = currentUser.ID;
            _repository.Insert(entity);
            if (commit)
            {
                UnitOfWork.Commit();

                if (entity is StrongEntity)
                {
                    StrongEntityDTO strongDto = newDto as StrongEntityDTO;
                    if (strongDto != null)
                    {
                        strongDto.Id = (entity as StrongEntity).Id;
                    }
                }
            }

        }

        public virtual TDTO InsertAndReturn(TDTO newDto)
        {
            var entity = newDto.ToEntity<TEntity>();
            _repository.Insert(entity);

            UnitOfWork.Commit();
            return entity.ToDTO<TDTO>();


        }

        public virtual void Update(TDTO dto, bool commit = true)
        {
            var entity = dto.ToEntity<TEntity>();
            _repository.Update(entity);
            if (commit)
                UnitOfWork.Commit();

        }

        //public virtual TDTO UpdateAndReturn(TDTO dto)
        //{
        //    var entity = dto.ToEntity<TEntity>();
        //    _repository.Update(entity);

        //    UnitOfWork.Commit();
        //    return entity.ToDTO<TDTO>();
        //}

        public IEnumerable<R> Query<R>(string sql, object param = null)
        {
            var cs = UnitOfWork.GetConnStr();
            using (OracleConnection connection = new OracleConnection(cs))
            {
                var data = connection.Query<R>(sql, param);
                return data;
            }
        }

        public IEnumerable<R> QuerySP<R>(string sql, object param = null)
        {
            var cs = UnitOfWork.GetConnStr();
            using (OracleConnection connection = new OracleConnection(cs))
            {
                var data = connection.Query<R>(sql, param, commandType:CommandType.StoredProcedure);
                return data;
            }
        }

        //public virtual bool BulkInsert(List<TDTO> dtos, out string errorMessage)
        //{
        //    var entities = dtos.ToEntityList<TEntity>();
        //    return _repository.BulkInsert(entities, out errorMessage);
        //}

        //public R BulkAction<R>(Func<R> func,bool transactional, out string errorMessage)
        //{
        //    return _repository.BulkAction(func, transactional, out errorMessage);
        //}

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (UnitOfWork != null)
                {
                    UnitOfWork.Dispose();
                    UnitOfWork = null;
                }
            }
        }
        public PaginatedResult<TDTO> GetAllPaginated(PaginatedRequest param)
        {
            var data = _repository.Get();
            return data.ToDTOPaginatedResult<TEntity, TDTO>(param);
        }
        
        protected PaginatedResult<TDTO> GetOrderedPaginated(PaginatedRequest param, IOrderedQueryable<TEntity> filter)
        {
            return filter.ToDTOPaginatedResult<TEntity, TDTO>(param);
        }
        protected PaginatedResult<TDTO> GetPaginated(PaginatedRequest param, IQueryable<TEntity> filter)
        {
            return filter.ToDTOPaginatedResult<TEntity, TDTO>(param);
        }

        protected string[] GetInclustionString<TProperty>(Expression<Func<TDTO, TProperty>>[] selectors)
        {
            var inclusions = new List<string>();
            if (selectors != null)
            {
                foreach (var selector in selectors)
                {
                    var mExp = selector.Body as MemberExpression;
                    if (mExp == null)
                        throw new ArgumentException("Expression should be a member expression");
                    string val = string.Empty;
                    if (mExp.Expression is MemberExpression)
                        val += (mExp.Expression as MemberExpression).Member.Name.Replace(DtoPostfix, string.Empty);
                    inclusions.Add(val);

                }
            }
            return inclusions.ToArray();
        }

        public virtual bool IsDuplicate(TDTO dto)
        {
            throw new NotImplementedException("پیاده سازی نشده است");
        }


        protected IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, bool v = false)
        {
            
            return _repository.Get(filter, v);
        }

        protected IQueryable<R> Get<R>(Expression<Func<R, bool>> filter = null)
        where R : BaseEntity
        {
            return UnitOfWork.Repository<R>().Get(filter);
        }

        protected List<TDTO> ToDTOList(IQueryable<TEntity> data)
        {
            return data.ToDTOList<TDTO>();
        }


    }
}
