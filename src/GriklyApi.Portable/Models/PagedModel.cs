// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagedModel.cs" company="">
//   
// </copyright>
// <summary>
//   The paging model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GriklyApi.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The paging model.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class PagingModel<T>
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the collection.
        /// </summary>
        public List<T> Collection { get; set; }

        /// <summary>
        /// Gets or sets the next page uri.
        /// </summary>
        public string NextPageUri { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the previous page uri.
        /// </summary>
        public string PreviousPageUri { get; set; }

        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the total page.
        /// </summary>
        public int TotalPage { get; set; }

        #endregion
    }
}