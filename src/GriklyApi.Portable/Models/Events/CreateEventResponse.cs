using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GriklyApi.Models.Events
{
    public class CreateEventResponse : BaseCreateResponse
    {
        public CreateEventResponse(Guid id)
            : base(id)
        {
        }
    }
}
