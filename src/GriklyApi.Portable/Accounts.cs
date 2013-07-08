using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Grikly.Models;
using System;
using Newtonsoft.Json;

namespace Grikly
{
    public partial class GriklyApi
    {
        /// <summary>
        /// Get a valid User by Email and Password
        /// </summary>
        /// <param name="login">The login.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public Task<IHttpResponse<User>> GetValidUser(LoginModel login, CancellationToken token)
        {
            string path = "Account/Login";
            return Execute<User>(new HttpRequest
                                     {
                                         Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(login)),
                                         Method = "POST",
                                         ContentType = "application/json"
                                     }, path, token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="register"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IHttpResponse<User>> Register(RegisterModel register, CancellationToken token)
        {
            string path = "Account/Register";
            return Execute<User>(new HttpRequest
            {
                Method = "POST",
                Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(register)),
                ContentType = "application/json"
            }, path, token);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IHttpResponse<bool>> EmailExist(string email, CancellationToken token)
        {
            string path = string.Format("Account/EmailExist?Email={0}", email);
            return Execute<bool>(new HttpRequest
            {
                Method = "GET"
            }, path,token);
        }
    }
}