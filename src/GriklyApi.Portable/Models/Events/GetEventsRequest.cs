using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GriklyApi.Models.Events
{
    /// <summary>
    /// 
    /// </summary>
    public class GetEventsRequest : PagedModelRequest
    {
        public GetEventsRequest(int page, int pageSize, string sort)
            : base(page, pageSize, sort)
        {
        }

        public string DateType { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}
