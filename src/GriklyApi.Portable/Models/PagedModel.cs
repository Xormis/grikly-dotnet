// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagedModel.cs" company="">
//   
// </copyright>
// <summary>
//   The paging model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GriklyApi.Models
{
    /// <summary>
    /// The paging model.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagingModel<T>
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the collection.
        /// </summary>
        /// <value>
        /// The collection.
        /// </value>
        public List<T> Collection { get; set; }

        /// <summary>
        /// Gets or sets the next page uri.
        /// </summary>
        /// <value>
        /// The next page URI.
        /// </value>
        public string NextPageUri { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the previous page uri.
        /// </summary>
        /// <value>
        /// The previous page URI.
        /// </value>
        public string PreviousPageUri { get; set; }

        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        /// <value>
        /// The total count.
        /// </value>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the total page.
        /// </summary>
        /// <value>
        /// The total page.
        /// </value>
        public int TotalPage { get; set; }

        #endregion
    }
}