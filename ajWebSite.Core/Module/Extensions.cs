using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ajWebSite.Core.Contracts.DTOs;
using ajWebSite.Core.Contracts.Entities;

namespace ajWebSite.Core.Module
{
    public static class Extensions
    {
        public static string getPersian(this DateTime value)
        {
            if (value == null)
            {
                return "";
            }
            System.Globalization.PersianCalendar persianCalandar =
                                    new System.Globalization.PersianCalendar();

            int year = persianCalandar.GetYear(value);
            int month = persianCalandar.GetMonth(value);
            int day = persianCalandar.GetDayOfMonth(value);
            return year + "-" + month + "-" + day;
        }
        public static string getPersian(this DateTime? value)
        {
            try
            {
                if (value == null)
                {
                    return "";
                }
                System.Globalization.PersianCalendar persianCalandar =
                                        new System.Globalization.PersianCalendar();

                int year = persianCalandar.GetYear(value ?? DateTime.Now);
                int month = persianCalandar.GetMonth(value ?? DateTime.Now);
                int day = persianCalandar.GetDayOfMonth(value ?? DateTime.Now);
                return year + "-" + month + "-" + day;

            }
            catch (Exception ex )
            {
                return ""; 
            }
        }
        public static void copyItemsWithSuchNames(this object sourceObject,object destObject)
        {
            foreach (var sourceProperty in sourceObject.GetType().GetProperties())
            {
                try
                {
                    var destproperty = destObject.GetType().GetProperties().FirstOrDefault(o => o.Name.ToLower() == sourceProperty.Name.ToLower());
                    if (destproperty != null)
                    {
                        destproperty.SetValue(destObject, sourceProperty.GetValue(sourceObject));
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public static DateTime getmiladiDateTime(this string value)
        {
            // Convert to Miladi
            DateTime dt = DateTime.Parse(value, new CultureInfo("fa-IR"));
            // Get Utc Date
            var dt_utc = dt.ToUniversalTime();
            return dt_utc;
        }
        #region Queryable Extensions

        public static IMapper Mapper { get; set; }
        public static PaginatedResult<T> ToPaginatedResult<T>(this IOrderedQueryable<T> query,
            PaginatedRequest request)
            where T : class
        {
            var dsResult = query.Skip(request.Skip).Take(request.Take).AsNoTracking();

            var toReturn = new PaginatedResult<T>
            {
                Items = dsResult as IEnumerable<T>,
                TotalCount = query.Count(),
                CurrentPage = request.Skip,
                PageSize = request.Take
            };
            return toReturn;
        }
        public static PaginatedResult<TDTO> ToDTOPaginatedResult<TEntity, TDTO>(this IOrderedQueryable<TEntity> query,
            PaginatedRequest request)
            where TEntity : BaseEntity
            where TDTO : class // not important to be BaseDTO
        {
            var projectQuery = query.ProjectTo<TDTO>(Mapper.ConfigurationProvider);

            var dsResult = projectQuery.Skip(request.Skip).Take(request.Take).AsNoTracking().ToList();
            var toReturn = new PaginatedResult<TDTO>
            {
                Items = dsResult.ToList(),
                TotalCount = projectQuery.Count(),
                CurrentPage = request.Skip,
                PageSize = request.Take
            };
            return toReturn;
        }

        public static PaginatedResult<TDTO> ToDTOPaginatedResult<TEntity, TDTO>(this IQueryable<TEntity> query,
            PaginatedRequest request)
            where TEntity : BaseEntity
            where TDTO : class//BaseEntityDTO
        {
            if (request.HasSort)
                query = query.OrderBy(request.Sort);
            else
                query = query.OrderByDescending(x => x.DateInserted);

            var projectQuery = query.ProjectTo<TDTO>(Mapper.ConfigurationProvider);



            var dsResult = projectQuery.Skip(request.Skip).Take(request.Take).AsNoTracking().ToList();
            //var dsResult = query.Skip(request.Offset).Take(request.Limit);
            var toReturn = new PaginatedResult<TDTO>
            {
                Items = dsResult.ToList(),
                TotalCount = projectQuery.Count(),
                CurrentPage = request.Skip,
                PageSize = request.Take
            };
            return toReturn;
        }
        #endregion

        #region Mapping Extensions

        public static TDTO ToDTO<TDTO>(this BaseEntity entity)
            where TDTO : class
        {
            if (entity == null)
                return null;
            return Mapper.Map<TDTO>(entity);
        }

        public static TEntity ToEntity<TEntity>(this BaseEntityDTO dto)
            where TEntity : BaseEntity
        {
            if (dto == null)
                return default(TEntity);
            return Mapper.Map<TEntity>(dto);
        }

        public static List<TDTO> ToDTOList<TDTO>(this IQueryable<BaseEntity> entityList)
            where TDTO : class
        {
            if (entityList == null)
                return null;
            return entityList.ProjectTo<TDTO>(Mapper.ConfigurationProvider).ToList();
        }

        public static List<TEntity> ToEntityList<TEntity>(this IEnumerable<BaseEntityDTO> dtoList)
            where TEntity : BaseEntity
        {
            if (dtoList == null)
                return null;
            return dtoList.Select(e => e.ToEntity<TEntity>()).ToList();
        }



        private static TDest Map<TDest>(object obj)
        {
            return Mapper.Map<TDest>(obj);
        }


        public static List<TDTO> DataReaderToEntityList<TDTO>(this DbDataReader dr) where TDTO : class
        {

            List<TDTO> list = new List<TDTO>();
            TDTO obj = default(TDTO);

            //if (!dr.HasRows)
            //    return list;
            try
            {
                while (dr.Read())
                {
                    obj = Activator.CreateInstance<TDTO>();
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        if (dr[i] is DBNull)
                            continue;
                        obj.GetType().GetProperty(dr.GetName(i)).SetValue(obj, dr[i], null);
                    }
                    list.Add(obj);
                }
            }
            catch (Exception ex) { }
            return list;
        }


        #endregion

    }

}
