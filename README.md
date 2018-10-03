# netcorepaginator
Pagination library for Asp.NetCoreMvc

#Installation 
`composer require crystoline/netcorepaginator`
or
`https://github.com/crystoline/netcorepaginator.git`
##Usage/Examples

**In Controller**

	 public class InvoiceController : BusinessBase
    {
        public IPaginate<MyModel> MyModelPaginateService { get; }
        private readonly IUrlHelper _urlHelper;

        public InvoiceController(ApplicationDbContext context, IUrlHelper urlHelper, IPaginate<MyModel> myModelPaginateService) :
        {
            this.MyModelPaginateService = myModelPaginateService;
            this._urlHelper = urlHelper;
        }
		
        public IActionResult All([FromRoute ]Guid Id, [FromQuery] PagingParams pagingParams)
		{
            IQueryable<MyModel> data = _context.MyModels.Where(i => i.Id == Id);
            var pagedList = new PagedList<MyModel>(data, pagingParams);
            var pages = new PaginateResponse<MyModel>(pagedList, "All", _urlHelper);
            return Ok(pages);
        }
	}
**Response**
	
	{
    "paging": {
        "totalItems": Int,
        "pageNumber": Int,
        "pageSize": Int,
        "totalPages": Int
    },
    "links": [
        {
            "pageNumber": Int,
            "href": "urlpath?PageNumber=3&PageSize=1",
            "rel": "previous",
            "method": "GET"
        },
        {
            "pageNumber": Int,
            "href": "urlpath?PageNumber=3&PageSize=2",
            "rel": "self",
            "method": "GET"
        },
		{
            "pageNumber": Int,
            "href": "urlpath?PageNumber=3&PageSize=3",
            "rel": "next",
            "method": "GET"
        },
    ],
    "data": {
        "totalItems": Int,
        "pageNumber": Int,
        "pageSize": Int,
        "list": [], //List Records here
        "totalPages": Int,
        "hasPreviousPage": bool,
        "hasNextPage": bool,
        "nextPageNumber": Int,
        "previousPageNumber": Int,
        "from": Int,
        "to": Int
    }
}
