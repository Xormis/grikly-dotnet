using System;

namespace GriklyApi.Models.Events
{
    /// <summary>
    /// 
    /// </summary>
    public class GetEventsRequest : PagedModelRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetEventsRequest"/> class.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="sort">The sort.</param>
        public GetEventsRequest(int page, int pageSize, string sort)
            : base(page, pageSize, sort)
        {
        }

        /// <summary>
        /// Gets or sets the type of the date.
        /// </summary>
        /// <value>
        /// The type of the date.
        /// </value>
        public string DateType { get; set; }
        /// <summary>
        /// Gets or sets the start.
        /// </summary>
        /// <value>
        /// The start.
        /// </value>
        public DateTime? Start { get; set; }
        /// <summary>
        /// Gets or sets the end.
        /// </summary>
        /// <value>
        /// The end.
        /// </value>
        public DateTime? End { get; set; }
    }
}