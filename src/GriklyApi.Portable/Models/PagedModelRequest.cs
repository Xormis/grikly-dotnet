namespace GriklyApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class PagedModelRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedModelRequest"/> class.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="sort">The sort.</param>
        public PagedModelRequest(int page, int pageSize, string sort)
        {
            Page = page;
            PageSize = pageSize;
            Sort = sort;
        }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        public virtual int Page { get; set; }
        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public virtual int PageSize { get; set; }
        /// <summary>
        /// Gets or sets the sort.
        /// </summary>
        /// <value>
        /// The sort.
        /// </value>
        public virtual string Sort { get; set; }
    }
}