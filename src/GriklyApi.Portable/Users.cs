using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Grikly.Models;
using System;

namespace Grikly
{
    public partial class GriklyApi
    {
        public Task<IHttpResponse<User>> GetUser(int id, CancellationToken token)
        {
            string path = string.Format("Users/{0}", id);
            return Execute<User>(new HttpRequest
                        {
                            Method = "GET"
                        }, path, token);
        }

        public Task<IHttpResponse<User>>  UploadProfileImage(int id, byte[] data, string contentType, CancellationToken token)
        {
            string path = string.Format("Users/{0}/ProfileImage", id);

            var boundary = "----" + DateTime.Now.Ticks;
            var fileHeaderFormat = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type= {3}\r\n", boundary, "image", "image", contentType);
            byte[] postData;
            using (MemoryStream ms = new MemoryStream())
            {

                StreamWriter writer = new StreamWriter(ms);
                writer.Write(fileHeaderFormat);
                writer.Flush();
                // You could also just use StreamWriter to do "writer.Write(bytes)"
                ms.Write(data, 0, data.Length);
                
                writer.Write("\r\n--" + boundary + "--\r\n");
                writer.Flush();
                postData = ms.ToArray();
            }
            return Execute<User>(new HttpRequest
            {
                Method = "POST",
                ContentType = "multipart/form-data; boundary=" + boundary,
                Body = postData
            }, path, token);
        }
    }
}