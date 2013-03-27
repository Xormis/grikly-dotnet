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
        private bool credentialsUsed = false;
        public string ApiKey { get; private set; }

        //intention is to remove usernames and password requirements in version 2 (using OAUTH)
        public string Email { get; private set; }

        public string Password { get; private set; }

        #region Fields

        #endregion Fields

        public GriklyApi(string apiKey, bool useSsl = true)
        {
            ApiKey = apiKey;

        }

        public void AddValidUserCredentials(string email, string password)
        {
            Email = email;
            Password = password;
            credentialsUsed = true;
        }
        
        public void Execute(IHttpRequest request, string path, Action<IHttpResponse> callback)
        {
            //build up the uri
            UriBuilder uriBuilder = new UriBuilder(Configuration.BASE_URL+path);
            var wr = (HttpWebRequest)HttpWebRequest.Create(uriBuilder.Uri);

            //transfer details from request to wr
            wr.ContentType = request.ContentType;
            wr.Method = request.Method;
            if(credentialsUsed)
            {
                string authInfo = Email + ":" + Password;
                authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(authInfo));
                wr.Headers["Authorization"] = "Basic " + authInfo;
            }
            
            foreach (var header in request.Headers)
            {
                wr.Headers[header.Key] = header.Value;
            }

            if(wr.Method != "GET")
            {
                wr.BeginGetRequestStream(new AsyncCallback(ExecutePost), new HttpWebRequestData
                                                                             {
                                                                                 Data = request.Body,
                                                                                 Request = wr,
                                                                                 ResponseCallback = callback
                                                                             });
            }
            else
            {
                ExecuteGet(wr, callback);
            }
        }

        public void ExecutePost(IAsyncResult asyncResult)
        {
            HttpWebRequestData requestData = asyncResult.AsyncState as HttpWebRequestData;
            HttpWebRequest request = requestData.Request;

            byte[] data = UTF8Encoding.UTF8.GetBytes(requestData.Data);
            using(Stream requestStream = request.EndGetRequestStream(asyncResult))
            {
                requestStream.Write(data, 0, data.Length);
                requestStream.Flush();
                //requestStream;
            }

            request.BeginGetResponse(new AsyncCallback(ExecutePostResponseCallback), requestData);

        }

        private void ExecutePostResponseCallback(IAsyncResult ar)
        {

            //Ignoring error handling here to keep things simple
            HttpWebRequestData requestData = ar.AsyncState as HttpWebRequestData;
            try
            {
                HttpWebResponse response = requestData.Request.EndGetResponse(ar) as HttpWebResponse;
                Stream responseStream = response.GetResponseStream();
                //memory stream needed because we need to convert the stream to a byte array
                var memoryStream = new MemoryStream();
                responseStream.CopyTo(memoryStream);


                requestData.ResponseCallback(new HttpResponse
                                                 {
                                                     IsError = false,
                                                     RawBytes = memoryStream.ToArray(),
                                                     ContentLength = response.ContentLength,
                                                     ContentType = response.ContentType
                                                 });
            }catch(WebException wex)
            {
                HandleRequestError(requestData.ResponseCallback, wex);
            }

        }

        private void ExecuteGet(WebRequest wr, Action<IHttpResponse> callback)
        {
            wr.BeginGetResponse(delegate(IAsyncResult ar)
                                    {
                                        try
                                        {
                                            //A WebException would be thrown here if status code isn't good
                                            using (var resp = wr.EndGetResponse(ar))
                                            {

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
                                        }
                                        catch (WebException webException)
                                        {
                                            //Catch the exeption here and return properly formatted model.
                                            HandleRequestError(callback, webException);
                                        }
                                    }, wr);
        }

        private void HandleRequestError(Action<IHttpResponse> callback, WebException webException)
        {
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

        public void Execute<T>(IHttpRequest request, string path, Action<IHttpResponse<T>> callback)
        {
            Execute(request, path, result =>
                                       {
                                           IHttpResponse<T> res = new HttpResponse<T>(result);
                                           try
                                           {
                                               //if error, there will be nothing to deserialize
                                               if (!result.IsError)
                                               {
                                                   //deserialize
                                                   string data = Encoding.UTF8.GetString(result.RawBytes, 0,
                                                                                         result.RawBytes.Length);
                                                   var objData = JsonConvert.DeserializeObject<T>(data);
                                                   res.Data = objData;

                                               }
                                           }
                                           catch (FormatException fex)
                                           {
                                               res.IsError = true;
                                               res.Error = new ErrorResponse
                                                               {
                                                                   Message = new ErrorMessage
                                                                                 {
                                                                                     Message = "Error with Server",
                                                                                     ExceptionMessage = fex.Message
                                                                                 }
                                                               };
                                           }
                                           catch (Exception ex)
                                           {
                                               res.IsError = true;
                                               res.Error = new ErrorResponse
                                               {
                                                   Message = new ErrorMessage
                                                   {
                                                       Message = "Internal Exception Occured",
                                                       ExceptionMessage = ex.Message
                                                   }
                                               };
                                           }
                                           callback(res);
                                       });
        }
    }
}