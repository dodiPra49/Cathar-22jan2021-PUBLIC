using System;
using System.Collections.Generic;
using System.Linq;

namespace New.Models
{
    public static class LinqExtensions
    {

        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query,
                                                int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);
            

            var skip = (page - 1) * pageSize;
            // // result.Results = query.Skip(skip).ToList();
            // // result.Results = result.Results.Take(pageSize).ToList();


            // var q = query.Skip(skip).Take(pageSize).ToList();
            // result.Results = q;
            // // result.Results = result.Results.ski(pageSize).ToList();

            // // result.Results = result.Results.Skip(skip).ToList();
 
            // // query = query.AsQueryable();
            // // result.Results = query.Skip(skip).Take(pageSize).ToList();
            result.Results = query.Skip(skip).Take(pageSize).ToList();
            // result.Results = query.ToList();

            return result;
        }
    }
}