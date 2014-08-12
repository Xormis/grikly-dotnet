using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GriklyApi.Models
{
    public class ResetPasswordModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        public string Code { get; set; }
    }
}
