using System;

namespace GriklyApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseCreateResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseCreateResponse"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected BaseCreateResponse(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }
    }
}