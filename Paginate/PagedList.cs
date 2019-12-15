using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paginator.Paginate
{
    public class PagedList<T>
    {
        public PagedList(IQueryable<T> source, PagingParams pagingParams)
        {
           
            this.PageNumber = pagingParams.PageNumber;
            this.PageSize = pagingParams.PageSize;
            this.TotalItems = source.Count();
            this.List = GenearateList(source);
        }

        public PagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
           
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.TotalItems = source.Count();
            this.List = GenearateList(source);
        }

        private List<T> GenearateList(IQueryable<T> source)
        {
            return source.Skip(PageSize * (PageNumber - 1))
                            .Take(PageSize)
                            .ToList();
        }

        public int TotalItems { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public List<T> List { get; }
        public int TotalPages => (int)Math.Ceiling(this.TotalItems / (double)this.PageSize);
        public bool HasPreviousPage => this.PageNumber > 1;
        public bool HasNextPage => this.PageNumber < this.TotalPages;
        public int NextPageNumber => this.HasNextPage ? this.PageNumber + 1 : this.TotalPages;
        public int PreviousPageNumber => this.HasPreviousPage ? this.PageNumber - 1 : 1;

        public int From => GetFrom();
        public int To => GetTo();
        
        private int GetFrom(){
            if(PageNumber == 1) return 1;
            else return ((PageNumber -1)  * PageSize) + 1;
        }

        private int GetTo(){
            var next = PageNumber  * PageSize;
            if (next <= TotalItems){
              return next;
            }

            var from = GetFrom();
            return from + (TotalItems - from);
        }

        public PagingHeader GetHeader()
        {
            return new PagingHeader(
                 this.TotalItems, 
                 this.PageNumber,
                 this.PageSize, 
                 this.TotalPages
           );
        }
    }
}
  
