using System;
using System.IO;
using System.Net;
using System.Text;
using Grikly.Models;
using Grikly.Utilities;
using Newtonsoft.Json;

namespace Grikly
{
    public partial class GriklyApi
    {
        public string ApiKey { get; private set; }

        //intention is to remove usernames and password requirements in version 2 (using OAUTH)
        public int UserId { get; private set; }

        public string Password { get; private set; }

        #region Fields

        #endregion Fields

        public GriklyApi(string apiKey, bool useSsl = true)
        {
            ApiKey = apiKey;

        }

        public void AddValidUserCredentials(int userId, string password)
        {
            UserId = userId;
            Password = password;

        }

        public void Execute<T>(string path, string method, Action<RequestResult<T>> callback) where T : class 
        {
            //build up the uri
            UriBuilder uriBuilder = new UriBuilder(Configuration.BASE_URL);
            uriBuilder.Path = path;

            var wr = HttpWebRequest.Create(uriBuilder.Uri);
            wr.Headers["UserId"] = UserId.ToString();
            wr.Headers["Password"] = Password;
            wr.Method = method;

            wr.BeginGetResponse(delegate(IAsyncResult ar)
            {
                try
                {
                    //A WebException would be thrown here if status code isn't good
                    var resp = wr.EndGetResponse(ar);

                    using (Stream stream = resp.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                        String responseString = reader.ReadToEnd();
                        //deserialize the response string into the expected class.
                        //may throw error here, not sure yet, need to test
                        var response = JsonConvert.DeserializeObject<T>(responseString);

                        callback(new RequestResult<T>
                                     {
                                         IsError = false,
                                         Result = response
                                     });
                    }
                }
                catch(WebException webException)
                {
                    using (WebResponse response = webException.Response)
                    {
                        HttpWebResponse httpResponse = (HttpWebResponse)response;

                        using (Stream data = response.GetResponseStream())
                        {
                            string body = new StreamReader(data).ReadToEnd();
                            var errorResponse = new ErrorResponse
                                                    {
                                                        HttpStatusCode = httpResponse.StatusCode,
                                                        Message = body
                                                    };
   
                            callback(new RequestResult<T>
                                         {
                                             IsError = true,
                                             Error = errorResponse,
                                         });
                        }
                    }
                }
            }, wr);
        }
    }

    public class RequestResult<T> where T: class
    {
        public T Result { get; set; }
        public bool IsError { get; set; }
        public ErrorResponse Error { get; set; }
    }

    public class ErrorResponse
    {
        public HttpStatusCode HttpStatusCode;
        public ErrorMessage Message;
    }

    public class ErrorMessage
    {
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionType { get; set; }
    }
}