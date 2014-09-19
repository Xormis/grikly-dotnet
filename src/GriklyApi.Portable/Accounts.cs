// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Accounts.cs" company="">
//   
// </copyright>
// <summary>
//   The grikly api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GriklyApi
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using GriklyApi.Models;

    using Grikly;

    using Newtonsoft.Json;

    /// <summary>
    /// The grikly api.
    /// </summary>
    public partial class GriklyClient : IGriklyClient
    {
        #region Public Methods and Operators

        /// <summary>
        /// Logins the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public Task<IHttpResponse<AuthenticationModel>> Login(string email, string password, CancellationToken token)
        {
            string path = "Token";
            return
                this.Execute<AuthenticationModel>(
                    new HttpRequestMessage(HttpMethod.Post, path)
                    {
                        Content = new StringContent(string.Format("grant_type=password&username={0}&password={1}", email, password), Encoding.UTF8, "application/x-www-form-urlencoded")
                    }, token);
        }

        /// <summary>
        /// Determines whether [is credentials set].
        /// </summary>
        /// <returns></returns>
        public bool IsCredentialsSet()
        {
            return !string.IsNullOrEmpty(bearerToken);
        }

        /// <summary>
        /// Emails the exist.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        public Task<IHttpResponse<bool>> EmailExist(string email, CancellationToken token)
        {
            string path = string.Format("v1/Account/EmailExist?Email={0}", email);
            return this.Execute<bool>(new HttpRequestMessage(HttpMethod.Get, path), token);
        }

        /// <summary>
        /// Determines whether the currently logged in user has confirmed their email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public Task<IHttpResponse<bool>> IsUserConfirmed(CancellationToken token)
        {
            string path = "v1/Account/IsUserConfirmed";
            return this.Execute<bool>(new HttpRequestMessage(HttpMethod.Get, path), token);
        }

        /// <summary>
        /// Get the currently logged in user.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        public Task<IHttpResponse<User>> GetCurrentUserInfo(CancellationToken token)
        {
            string path = "v1/Account/UserInfo";
            return
                this.Execute<User>(new HttpRequestMessage(HttpMethod.Get, path), token);
        }

        /// <summary>
        /// Registers the specified register.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        public Task<IHttpResponse> Register(RegisterModel register, CancellationToken token)
        {
            string path = "v1/Account/Register";
            return this.Execute(new HttpRequestMessage(HttpMethod.Post, path)
                                    {
                                        Content = new StringContent(JsonConvert.SerializeObject(register), Encoding.UTF8, "application/json")
                                    }, token);
        }

        /// <summary>
        /// Resends the confirmation.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public Task<IHttpResponse> ResendConfirmation(string email, CancellationToken token)
        {
            string path = "v1/Account/ResendConfirmation";
            return this.Execute(new HttpRequestMessage(HttpMethod.Post, path)
            {
                Content = new StringContent(JsonConvert.SerializeObject(new { Email = email }), Encoding.UTF8, "application/json")
            }, token);
        }


        /// <summary>
        /// Recovers the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public Task<IHttpResponse> Recover(string email, CancellationToken token)
        {
            string path = "v1/Account/Recover";
            return
                this.Execute(
                    new HttpRequestMessage(HttpMethod.Post, path)
                        {
                            Content =
                                new StringContent(
                                JsonConvert.SerializeObject(
                                    new { Email = email }),
                                Encoding.UTF8,
                                "application/json")
                        },
                    token);
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public Task<IHttpResponse> ChangePassword(string oldPassword, string newPassword, CancellationToken token)
        {
            string path = "v1/Account/ChangePassword";
            return
                this.Execute(
                    new HttpRequestMessage(HttpMethod.Post, path)
                    {
                        Content =
                            new StringContent(
                            JsonConvert.SerializeObject(
                                new { OldPassword = oldPassword, NewPassword = newPassword }),
                            Encoding.UTF8,
                            "application/json")
                    },
                    token);
        }

        /// <summary>
        /// Confirms the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="code">The code.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public Task<IHttpResponse> ConfirmEmail(string email, string code, CancellationToken token)
        {
            string path = "v1/Account/ConfirmEmail";
            return
                this.Execute(
                    new HttpRequestMessage(HttpMethod.Post, path)
                    {
                        Content =
                            new StringContent(
                            JsonConvert.SerializeObject(
                                new { Email = email, Code = code }),
                            Encoding.UTF8,
                            "application/json")
                    },
                    token);
        }
        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="code">The code.</param>
        /// <param name="password">The password.</param>
        /// <param name="confirmPassword">The confirm password.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public Task<IHttpResponse> ResetPassword(string email, string code, string password, string confirmPassword, CancellationToken token)
        {
            string path = "v1/Account/ResetPassword";
            return
                this.Execute(
                    new HttpRequestMessage(HttpMethod.Post, path)
                    {
                        Content =
                            new StringContent(
                            JsonConvert.SerializeObject(
                                new { Email = email, Code = code, Password = password, ConfirmPassword = confirmPassword }),
                            Encoding.UTF8,
                            "application/json")
                    },
                    token);
        }
        /// <summary>
        /// Uploads the profile image.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        public Task<IHttpResponse<string>> UploadProfileImage(
            byte[] data,
            CancellationToken token)
        {
            string path = "v1/Account/ProfileImage";

            string boundary = "----" + DateTime.Now.Ticks;
            var requestContent = new MultipartFormDataContent(boundary);
            var imageContent = new ByteArrayContent(data);
            imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/png");

            requestContent.Add(imageContent, "image", "image.png");
            return this.Execute<string>(
                new HttpRequestMessage(HttpMethod.Post, path) { Content = requestContent },
                token);
        }
        #endregion

    }
}