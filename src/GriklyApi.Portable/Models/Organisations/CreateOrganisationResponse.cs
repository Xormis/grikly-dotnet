using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GriklyApi.Models;

namespace GriklyApi
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateOrganisationResponse : BaseCreateResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseCreateResponse" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public CreateOrganisationResponse(Guid id)
            : base(id)
        {
        }
    }
}
