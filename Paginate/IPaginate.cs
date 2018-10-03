using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paginator.Paginate
{
    public interface IPaginate<TModel>
    {
        PagedList<TModel> GetPage(PagingParams pagingParams, IQueryable<TModel> query);
    }
}
