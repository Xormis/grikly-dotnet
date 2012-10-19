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
        
        public void Execute(string path, string method, Action<IResponseResult> callback)
        {
            //build up the uri
            UriBuilder uriBuilder = new UriBuilder(Configuration.BASE_URL);
            uriBuilder.Path += path;

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
                        //memory stream needed because we need to convert the stream to a byte array
                        var memoryStream = new MemoryStream();
                        stream.CopyTo(memoryStream);


                        callback(new ResponseResult
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
                        HttpWebResponse httpResponse = (HttpWebResponse)response;

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

                            callback(new ResponseResult
                            {
                                IsError = true,
                                Error = errorResponse,
                            });
                        }
                    }
                }
            }, wr);
        }

        public void Execute<T>(string path, string method, Action<IResponseResult<T>> callback) where T : class
        {
            Execute(path, method, result =>
                                      {
                                          //deserialize
                                          string data = Encoding.UTF8.GetString(result.RawBytes, 0, result.RawBytes.Length);
                                          var objData = JsonConvert.DeserializeObject<T>(data);
                                          IResponseResult<T> res = new ResponseResult<T>(result);
                                          res.Data = objData;
                                          callback(res);
                                      });
        }
    }
}