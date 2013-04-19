using System.Text;
using Grikly.Models;
using System;
using Newtonsoft.Json;

namespace Grikly
{
    public partial class GriklyApi
    {
        /// <summary>
        /// Get a valid User by email and password
        /// </summary>
        /// <para name="login"></para>
        /// <returns></returns>
        public void GetValidUser(LoginModel login, Action<IHttpResponse<User>> callback)
        {
            string path = "Account/Login";
            Execute(new HttpRequest
            {
                Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(login)),
                Method = "POST",
                ContentType = "application/json"
            }, path, callback);
        }


        public void Register(RegisterModel register, Action<IHttpResponse<User>> callback)
        {
            string path = "Account/Register";
            Execute(new HttpRequest
            {
                Method = "POST",
                Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(register)),
                ContentType = "application/json"
            }, path, callback);
        }

        public void EmailExist(string email, Action<IHttpResponse<bool>> callback)
        {
            string path = string.Format("Account/EmailExist?Email={0}", email);
            Execute(new HttpRequest
            {
                Method = "GET"
            }, path, callback);
        }
    }
}