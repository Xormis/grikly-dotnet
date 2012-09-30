using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grikly.Utilities;
using RestSharp;

namespace Grikly
{
    public partial class GriklyApi
    {

        public string ApiKey { get; private set; }
        
        
        //intention is to remove usernames and password requirements in version 2 (using OAUTH)
        public string Username { get; private set; }
        public string Password { get; private set; }


        #region Fields
        /// <summary>
        /// the main rest client for use throughout the whole app.
        /// </summary>
        private RestClient client;

        #endregion Fields  

        public GriklyApi(string apiKey, string username, string password, bool useSsl = true)
        {
            ApiKey = apiKey;
            Username = username;
            Password = password;

            if (useSsl)
            {
                client = new RestClient(Configuration.BASE_SECURE_URL);
            }
            else
            {
                client = new RestClient(Configuration.BASE_URL);
            }
            client.AddHandler("application/json", new DynamicJsonDeserializer());
        }

    }
}
