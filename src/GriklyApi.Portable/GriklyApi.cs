// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GriklyApi.cs" company="">
//   
// </copyright>
// <summary>
//   Grik.ly API wrapper that contains REST API calls.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Grikly
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    /// <summary>
    ///     Grik.ly API wrapper that contains REST API calls.
    /// </summary>
    public partial class GriklyApi
    {
        // intention is to remove usernames and password requirements in version 2 (using OAUTH)
        #region Fields

        private bool useBetaUrl;

        /// <summary>
        /// The _credentials used.
        /// </summary>
        private bool _credentialsUsed;

        /// <summary>
        ///     The _email of the user to make authenticated requests
        /// </summary>
        private string _email;

        /// <summary>
        ///     The password of the user to make authenticated requests
        /// </summary>
        private string _password;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GriklyApi"/> class. 
        /// Create an instance of the Grik.ly API client.
        /// </summary>
        /// <param name="apiKey">
        /// </param>
        /// <param name="useSsl">
        /// </param>
        public GriklyApi(string apiKey, bool useSsl = true, bool useBetaUrl = false)
        {
            this.ApiKey = apiKey;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     The API Key that is used to validate requests to the server.
        /// </summary>
        public string ApiKey { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Add the credentials of the user to make authenticated requests
        /// </summary>
        /// <param name="email">
        /// the email
        /// </param>
        /// <param name="password">
        /// the password
        /// </param>
        public void AddCredentials(string email, string password)
        {
            this._email = email;
            this._password = password;
            this._credentialsUsed = true;
        }

        /// <summary>
        /// Remove the credentials of the user for making authenticated requests
        /// </summary>
        public void RemoveCredentials()
        {
            this._email = string.Empty;
            this._password = string.Empty;
            this._credentialsUsed = false;
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<IHttpResponse> Execute(IHttpRequest request, string path, CancellationToken token)
        {
            var baseUrl = useBetaUrl ? Configuration.BASE_BETA_URL : Configuration.BASE_URL;
            // build up the uri
            var uriBuilder = new UriBuilder(baseUrl + path);
            var wr = (HttpWebRequest)WebRequest.Create(uriBuilder.Uri);

            // transfer details from request to wr
            wr.ContentType = request.ContentType;
            wr.Method = request.Method;
            if (this._credentialsUsed)
            {
                string authInfo = this._email + ":" + this._password;
                authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(authInfo));
                wr.Headers["Authorization"] = "Basic " + authInfo;
            }

            // add api key to header
            wr.Headers["ApiKey"] = this.ApiKey;

            foreach (var header in request.Headers)
            {
                wr.Headers[header.Key] = header.Value;
            }

            if (wr.Method != "GET")
            {
                return Task.Factory.StartNew(
                    () =>
                        {
                            var t = new TaskCompletionSource<IHttpResponse>();
                            wr.BeginGetRequestStream(
                                this.ExecutePost, 
                                new HttpWebRequestData
                                    {
                                        Data = request.Body, 
                                        Request = wr, 
                                        ResponseCallback = s => t.TrySetResult(s)
                                    });

                            return t.Task;
                        }, 
                    token).Unwrap();
            }

            return Task.Factory.StartNew(
                () =>
                    {
                        var t = new TaskCompletionSource<IHttpResponse>();
                        this.ExecuteGet(wr, s => t.TrySetResult(s));
                        return t.Task;
                    }, 
                token).Unwrap();
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<IHttpResponse<T>> Execute<T>(IHttpRequest request, string path, CancellationToken token)
        {
            return this.Execute(request, path, token).ContinueWith(
                result =>
                    {
                        IHttpResponse<T> res = new HttpResponse<T>(result.Result);
                        try
                        {
                            // if error, there will be nothing to deserialize
                            if (!res.IsError)
                            {
                                // deserialize
                                string data = Encoding.UTF8.GetString(res.RawBytes, 0, res.RawBytes.Length);
                                var objData = JsonConvert.DeserializeObject<T>(data);
                                res.Data = objData;
                            }
                        }
                        catch (FormatException fex)
                        {
                            res.IsError = true;
                            res.Error = new ErrorResponse
                                            {
                                                Message =
                                                    new ErrorMessage
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
                                                Message =
                                                    new ErrorMessage
                                                        {
                                                            Message =
                                                                "Internal Exception Occured", 
                                                            ExceptionMessage = ex.Message
                                                        }
                                            };
                        }

                        return res;
                    });
        }

        /// <summary>
        /// The execute post.
        /// </summary>
        /// <param name="asyncResult">
        /// The async result.
        /// </param>
        public void ExecutePost(IAsyncResult asyncResult)
        {
            var requestData = asyncResult.AsyncState as HttpWebRequestData;
            HttpWebRequest request = requestData.Request;

            using (Stream requestStream = request.EndGetRequestStream(asyncResult))
            {
                requestStream.Write(requestData.Data, 0, requestData.Data.Length);
                requestStream.Flush();

                // requestStream;
            }

            request.BeginGetResponse(this.ExecutePostResponseCallback, requestData);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The execute get.
        /// </summary>
        /// <param name="wr">
        /// The wr.
        /// </param>
        /// <param name="callback">
        /// The callback.
        /// </param>
        private void ExecuteGet(WebRequest wr, Action<IHttpResponse> callback)
        {
            wr.BeginGetResponse(
                delegate(IAsyncResult ar)
                    {
                        try
                        {
                            // A WebException would be thrown here if status code isn't good
                            using (WebResponse resp = wr.EndGetResponse(ar))
                            {
                                using (Stream stream = resp.GetResponseStream())
                                {
                                    // memory stream needed because we need to convert the stream to a byte array
                                    var memoryStream = new MemoryStream();
                                    stream.CopyTo(memoryStream);

                                    callback(
                                        new HttpResponse
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
                            // Catch the exeption here and return properly formatted model.
                            this.HandleRequestError(callback, webException);
                        }
                    }, 
                wr);
        }

        /// <summary>
        /// The execute post response callback.
        /// </summary>
        /// <param name="ar">
        /// The ar.
        /// </param>
        private void ExecutePostResponseCallback(IAsyncResult ar)
        {
            // Ignoring error handling here to keep things simple
            var requestData = ar.AsyncState as HttpWebRequestData;
            try
            {
                var response = requestData.Request.EndGetResponse(ar) as HttpWebResponse;
                Stream responseStream = response.GetResponseStream();

                // memory stream needed because we need to convert the stream to a byte array
                var memoryStream = new MemoryStream();
                responseStream.CopyTo(memoryStream);

                requestData.ResponseCallback(
                    new HttpResponse
                        {
                            IsError = false, 
                            RawBytes = memoryStream.ToArray(), 
                            ContentLength = response.ContentLength, 
                            ContentType = response.ContentType
                        });
            }
            catch (WebException wex)
            {
                this.HandleRequestError(requestData.ResponseCallback, wex);
            }
        }

        /// <summary>
        /// The handle request error.
        /// </summary>
        /// <param name="callback">
        /// The callback.
        /// </param>
        /// <param name="webException">
        /// The web exception.
        /// </param>
        private void HandleRequestError(Action<IHttpResponse> callback, WebException webException)
        {
            using (WebResponse response = webException.Response)
            {
                var httpResponse = (HttpWebResponse)response;

                using (Stream data = response.GetResponseStream())
                {
                    string body = new StreamReader(data).ReadToEnd();

                    // try to deserialize the message
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

                    callback(new HttpResponse { IsError = true, Error = errorResponse, });
                }
            }
        }

        #endregion
    }
}