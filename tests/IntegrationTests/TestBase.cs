using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GriklyApi;

namespace Grikly.Tests.IntegrationTests
{
    public abstract class TestBase
    {
        protected readonly GriklyClient Client;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        protected TestBase()
        {
            var apiKey = ConfigurationManager.AppSettings["ApiKey"];
            Client = new GriklyClient(apiKey, true);
        }
    }
}
