using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GriklyApi.Models
{
    public abstract class BaseCreateResponse
    {
        protected BaseCreateResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
