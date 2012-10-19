using System.IO;
using System.Net;
using System.Text;
using Grikly.Models;
using System;

namespace Grikly
{
    public partial class GriklyApi
    {
        public void GetUser(int id, Action<IResponseResult<User>> callback)
        {
            string path = string.Format("Users/{0}", id);
            Execute(path, "GET", callback);
        }
    }
}