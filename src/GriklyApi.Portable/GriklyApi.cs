using System;
using System.IO;
using System.Net;
using System.Text;
using Grikly.Models;
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
        
        public void Execute(IHttpRequest request, string path, Action<IHttpResponse> callback)
        {
            //build up the uri
            UriBuilder uriBuilder = new UriBuilder(Configuration.BASE_URL);
            uriBuilder.Path += path;
            
            var wr = HttpWebRequest.Create(uriBuilder.Uri);
            string authInfo = UserId + ":" + Password;
            authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(authInfo));
            wr.Headers["Authorization"] = "Basic " + authInfo;
            foreach (var header in request.Headers)
            {
                wr.Headers[header.Key] = header.Value;
            }
            wr.Method = request.Method;
            //make the request with a content-body attached if method other than GET
            if (wr.Method != "GET")
            {
                wr.ContentType = request.ContentType;
                //write the input data (aka post) to a byte array
                byte[] requestBytes = Encoding.UTF8.GetBytes(request.Body);
                
                //get the request stream to write the post to
                wr.BeginGetRequestStream(delegate(IAsyncResult reqStreamAR)
                                             {

                                                 //write the post to the request stream
                                                 var requestStream = wr.EndGetRequestStream(reqStreamAR);
                                                 requestStream.Write(requestBytes, 0, requestBytes.Length);

                                                 ExecuteRequest(callback, wr);
                                             }, wr);
            }
            else
            {
                ExecuteRequest(callback, wr);
            }

        }

        private void ExecuteRequest(Action<IHttpResponse> callback, WebRequest wr)
        {
            wr.BeginGetResponse(delegate(IAsyncResult ar)
                                    {
                                        try
                                        {
                                            //A WebException would be thrown here if status code isn't good
                                            var resp = wr.EndGetResponse(ar);

                                            using (Stream stream = resp.GetResponseStream())
                                            {
                                                //memory stream needed because we need to convert the stream to a byte array
                                                var memoryStream = new MemoryStream();
                                                stream.CopyTo(memoryStream);


                                                callback(new HttpResponse
                                                             {
                                                                 IsError = false,
                                                                 RawBytes = memoryStream.ToArray(),
                                                                 ContentLength = resp.ContentLength,
                                                                 ContentType = resp.ContentType
                                                             });
                                            }
                                        }
                                        catch (WebException webException)
                                        {
                                            //Catch the exeption here and return properly formatted model.
                                            using (WebResponse response = webException.Response)
                                            {
                                                HttpWebResponse httpResponse = (HttpWebResponse) response;

                                                using (Stream data = response.GetResponseStream())
                                                {
                                                    string body = new StreamReader(data).ReadToEnd();

                                                    //try to deserialize the message
                                                    ErrorMessage errorMessage = null;
                                                    try
                                                    {
                                                        errorMessage = JsonConvert.DeserializeObject<ErrorMessage>(body);
                                                    }
                                                    catch (Exception)
                                                    {
                                                    }

                                                    var errorResponse = new ErrorResponse
                                                                            {
                                                                                HttpStatusCode = httpResponse.StatusCode,
                                                                                Message = errorMessage
                                                                            };

                                                    callback(new HttpResponse
                                                                 {
                                                                     IsError = true,
                                                                     Error = errorResponse,
                                                                 });
                                                }
                                            }
                                        }
                                    }, wr);
        }

        public void Execute<T>(IHttpRequest request, string path, Action<IHttpResponse<T>> callback) where T : class
        {
            Execute(request, path, result =>
                                       {
                                           IHttpResponse<T> res = new HttpResponse<T>(result);
                                           //if error, there will be nothing to deserialize
                                           if (!result.IsError)
                                           {
                                               //deserialize
                                               string data = Encoding.UTF8.GetString(result.RawBytes, 0,
                                                                                     result.RawBytes.Length);
                                               var objData = JsonConvert.DeserializeObject<T>(data);
                                               res.Data = objData;
                                           }
                                           callback(res);
                                       });
        }
    }
}