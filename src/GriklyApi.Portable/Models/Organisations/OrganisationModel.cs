using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GriklyApi
{
    /// <summary>
    /// 
    /// </summary>
    public class OrganisationModel
    {
        /// <summary>
        /// Gets or sets the organisation identifier.
        /// </summary>
        /// <value>
        /// The organisation identifier.
        /// </value>
        public virtual Guid OrganisationId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public virtual string Name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public virtual string Description { get; set; }
    }
}
