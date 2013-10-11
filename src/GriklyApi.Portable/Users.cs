// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Users.cs" company="">
//   
// </copyright>
// <summary>
//   The grikly api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Grikly
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using Grikly.Models;

    /// <summary>
    /// The grikly api.
    /// </summary>
    public partial class GriklyApi
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<IHttpResponse<User>> GetUser(int id, CancellationToken token)
        {
            string path = string.Format("Users/{0}", id);
            return this.Execute<User>(new HttpRequest { Method = "GET" }, path, token);
        }

        /// <summary>
        /// Uploads the profile image.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <param name="contentType">
        /// Type of the content.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<IHttpResponse<User>> UploadProfileImage(
            int id, 
            byte[] data, 
            string contentType, 
            CancellationToken token)
        {
            string path = string.Format("Users/{0}/ProfileImage", id);

            string boundary = "----" + DateTime.Now.Ticks;
            string fileHeaderFormat =
                string.Format(
                    "--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type= {3}\r\n", 
                    boundary, 
                    "image", 
                    "image", 
                    contentType);
            byte[] postData;
            using (var ms = new MemoryStream())
            {
                var writer = new StreamWriter(ms);
                writer.Write(fileHeaderFormat);
                writer.Flush();

                // You could also just use StreamWriter to do "writer.Write(bytes)"
                ms.Write(data, 0, data.Length);

                writer.Write("\r\n--" + boundary + "--\r\n");
                writer.Flush();
                postData = ms.ToArray();
            }

            return
                this.Execute<User>(
                    new HttpRequest
                        {
                            Method = "POST", 
                            ContentType = "multipart/form-data; boundary=" + boundary, 
                            Body = postData
                        }, 
                    path, 
                    token);
        }

        #endregion
    }
}