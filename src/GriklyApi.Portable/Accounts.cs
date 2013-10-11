// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Accounts.cs" company="">
//   
// </copyright>
// <summary>
//   The grikly api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Grikly
{
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using Grikly.Models;

    using Newtonsoft.Json;

    /// <summary>
    /// The grikly api.
    /// </summary>
    public partial class GriklyApi
    {
        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <param name="email">
        /// </param>
        /// <param name="token">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<IHttpResponse<bool>> EmailExist(string email, CancellationToken token)
        {
            string path = string.Format("Account/EmailExist?Email={0}", email);
            return this.Execute<bool>(new HttpRequest { Method = "GET" }, path, token);
        }

        /// <summary>
        /// Get a valid User by Email and Password
        /// </summary>
        /// <param name="login">
        /// The login.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<IHttpResponse<User>> GetValidUser(LoginModel login, CancellationToken token)
        {
            string path = "Account/Login";
            return
                this.Execute<User>(
                    new HttpRequest
                        {
                            Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(login)), 
                            Method = "POST", 
                            ContentType = "application/json"
                        }, 
                    path, 
                    token);
        }

        /// <summary>
        /// </summary>
        /// <param name="register">
        /// </param>
        /// <param name="token">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<IHttpResponse<User>> Register(RegisterModel register, CancellationToken token)
        {
            string path = "Account/Register";
            return
                this.Execute<User>(
                    new HttpRequest
                        {
                            Method = "POST", 
                            Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(register)), 
                            ContentType = "application/json"
                        }, 
                    path, 
                    token);
        }

        #endregion
    }
}