using System;

namespace GriklyApi.Models.Events
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateEventResponse : BaseCreateResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEventResponse"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public CreateEventResponse(Guid id)
            : base(id)
        {
        }
    }
}