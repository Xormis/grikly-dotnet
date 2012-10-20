﻿using System.IO;
using System.Net;
using System.Text;
using Grikly.Models;
using System;

namespace Grikly
{
    public partial class GriklyApi
    {
        public void GetUser(int id, Action<IHttpResponse<User>> callback)
        {
            string path = string.Format("Users/{0}", id);
            Execute(new HttpRequest
                        {
                            Method = "GET"
                        }, path, callback);
        }
    }
}