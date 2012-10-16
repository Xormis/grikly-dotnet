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
                        T response = null;
                        try
                        {
                            JsonConvert.DeserializeObject<T>(responseString);
                        }
                        catch(Exception ex)
                        {
                            
                        }
                        callback(new RequestResult<T>
                                     {
                                         IsError = false,
                                         Result = response
                                     });
                    }
                }
                catch(WebException webException)
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
}