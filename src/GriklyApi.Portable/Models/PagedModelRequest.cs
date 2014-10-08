using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GriklyApi.Models
{
    public class PagedModelRequest
    {
        public PagedModelRequest(int page, int pageSize, string sort)
        {
            Page = page;
            PageSize = pageSize;
            Sort = sort;
        }

        public virtual int Page { get; set; }
        public virtual int PageSize { get; set; }
        public virtual string Sort { get; set; }
    }
}
