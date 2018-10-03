using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paginator.Paginate
{
    public class PaginateResponse<T>
    {
        

        public PagingHeader Paging { get; set; }

        public List<LinkInfo> Links { get; set; }

        public PagedList<T> Data { get; set; }

        private IUrlHelper urlHelper;
        private string Path;

        public PaginateResponse(PagedList<T> data, string path, IUrlHelper urlHelper)
        {
            this.urlHelper = urlHelper;
            Path = path;

            Paging = data.GetHeader();
            Links = GetLinks(data);
            Data = data;
        }

        private List<LinkInfo> GetLinks(PagedList<T> data)
        {
            var links = new List<LinkInfo>();

            if (data.HasPreviousPage)
            {
                links.Add(CreateLink(Path, data.PreviousPageNumber,data.PageSize, "previous", "GET"));
            }
              
            links.Add(CreateLink(Path, data.PageNumber, data.PageSize, "self", "GET"));

            if (data.HasNextPage)
            {
                links.Add(CreateLink(Path, data.NextPageNumber, data.PageSize, "next", "GET"));
            }

            return links;
        }

        private LinkInfo CreateLink(string routeName, int pageNumber, int pageSize, string rel, string method)
        {
            return new LinkInfo
            {
               
                Href = urlHelper.Action(routeName, new { PageNumber = pageNumber, PageSize = pageSize }),
                Rel = rel,
                Method = method,
                PageNumber = pageNumber
            };
        }

    }
}
