using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paginator.Paginate
{
    public class Paginate<T> : IPaginate<T>
    {
        public PagedList<T> GetPage(PagingParams pagingParams, IQueryable<T> query)
        {
            return new PagedList<T>(query, pagingParams);
        }
    }
}
