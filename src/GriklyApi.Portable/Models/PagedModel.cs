using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GriklyApi.Models
{
    public class PagingModel<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public int TotalPage { get; set; }

        public int TotalCount { get; set; }

        public string NextPageUri { get; set; }
        public string PreviousPageUri { get; set; }
        public List<T> Collection { get; set; }

    }
}
