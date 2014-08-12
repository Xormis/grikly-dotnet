// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GriklyApi.cs" company="">
//   
// </copyright>
// <summary>
//   Grik.ly API wrapper that contains REST API calls.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GriklyApi
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using GriklyApi.Models;

    using Grikly;

    using Newtonsoft.Json;

    /// <summary>
    ///     Grik.ly API wrapper that contains REST API calls.
    /// </summary>
    public partial class GriklyClient : IGriklyClient
    {
        // intention is to remove usernames and password requirements in version 2 (using OAUTH)
        #region Fields

        /// <summary>
        ///     The _email of the user to make authenticated requests
        /// </summary>
        private string bearerToken;

        private readonly HttpClient client;

        /// <summary>
        /// The use beta url.
        /// </summary>
        private bool useBetaUrl;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GriklyClient"/> class.
        ///     Create an instance of the Grik.ly API client.
        /// </summary>
        /// <param name="apiKey">
        /// </param>
        /// <param name="useSsl">
        /// </param>
        /// <param name="useBetaUrl">
        /// The use Beta Url.
        /// </param>
        public GriklyClient(string apiKey, bool useSsl = true, bool useBetaUrl = false)
        {
            this.ApiKey = apiKey;
            this.useBetaUrl = useBetaUrl;

            string baseUrl = this.useBetaUrl ? Configuration.BASE_BETA_URL : Configuration.BASE_URL;

            client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);

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
        public void AddCredentials(string bearerToken)
        {
            this.bearerToken = bearerToken;
        }
        public async Task<IHttpResponse> Execute(HttpRequestMessage request, CancellationToken token)
        {
            if (!string.IsNullOrEmpty(bearerToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            }

            // add api key to header
            request.Headers.Add("ApiKey", ApiKey);

            var originalResponse = await client.SendAsync(request, token);

            if (originalResponse.IsSuccessStatusCode)
            {
                var content = await originalResponse.Content.ReadAsByteArrayAsync();
                var createdContentId = originalResponse.Headers.Contains("CreatedContentId")
                                           ? originalResponse.Headers.GetValues("CreatedContentId")
                                                 .FirstOrDefault()
                                           : "";
                var contentLocation = originalResponse.Headers.Location != null
                                          ? originalResponse.Headers.Location.AbsoluteUri
                                          : "";
                var contentType = originalResponse.Content.Headers.ContentType != null
                                    ? originalResponse.Content.Headers.ContentType.MediaType
                                    : "";
                var response = new HttpResponse
                                   {
                                       IsError = false,
                                       RawBytes = content,
                                       ContentLength = originalResponse.Content.Headers.ContentLength.Value,
                                       ContentType = contentType,
                                       Location = contentLocation,
                                       CreatedContentId = createdContentId
                                   };
                return response;

            }
            else
            {
                var content = await originalResponse.Content.ReadAsStringAsync();

                var errorMessage = new ErrorMessage
                                                    {
                                                        Message = "An error occurred with your request."
                                                    };

                // try to deserialize the message
                if (!string.IsNullOrEmpty(content)) errorMessage = JsonConvert.DeserializeObject<ErrorMessage>(content);

                var errorResponse = new ErrorResponse
                                            {
                                                HttpStatusCode = originalResponse.StatusCode,
                                                ErrorMessage = errorMessage
                                            };

                return new HttpResponse { IsError = true, Error = errorResponse, };
            }
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
        public async Task<IHttpResponse<T>> Execute<T>(HttpRequestMessage request, CancellationToken token)
        {
            var originalResponse =  await this.Execute(request, token);
            var response = new HttpResponse<T>(originalResponse);
            // if no error, deserialize the content to the generic data property
            if (!response.IsError)
            {
                try
                {
                    string data = Encoding.UTF8.GetString(response.RawBytes, 0, response.RawBytes.Length);
                    var objData = JsonConvert.DeserializeObject<T>(data);
                    response.Data = objData;
                }
                catch (FormatException fex)
                {
                    response.IsError = true;
                    response.Error = new ErrorResponse
                                    {
                                        ErrorMessage =
                                            new ErrorMessage
                                                {
                                                    Message = "Error with Server",
                                                    ExceptionMessage = fex.Message
                                                }
                                    };
                }
                catch (Exception ex)
                {
                    response.IsError = true;
                    response.Error = new ErrorResponse
                                    {
                                        ErrorMessage =
                                            new ErrorMessage
                                                {
                                                    Message = "Internal Exception Occured",
                                                    ExceptionMessage = ex.Message
                                                }
                                    };
                }
            }
            return response;
        }


        /// <summary>
        ///     Remove the credentials of the user for making authenticated requests
        /// </summary>
        public void RemoveCredentials()
        {
            bearerToken = string.Empty;
        }

        #endregion

    }
}