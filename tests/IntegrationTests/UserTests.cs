using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;

namespace Grikly.Tests.IntegrationTests
{
    [TestFixture]
    public class UserTests
    {
        private string apiKey;
        private string userEmail;
        private string userPassword;

        [SetUp]
        public void SetUp()
        {
            apiKey = ConfigurationManager.AppSettings["APIKey"];
            userEmail = ConfigurationManager.AppSettings["UserEmail"];
            userPassword = ConfigurationManager.AppSettings["UserPassword"];
        }

        [TearDown]
        public void TearDown()
        {
            
        }


    }
}
