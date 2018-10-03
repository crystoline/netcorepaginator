using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paginator.Paginate
{
    public class LinkInfo
    {
        public int PageNumber;

        public string Href { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }
    }
}
