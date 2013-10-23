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
        [Ignore]
        [Test]
        public void Profile_Image_Can_Be_Uploaded()
        {
            var api = new GriklyApi(apiKey);
            api.AddCredentials(userEmail,userPassword);
            var userId = int.Parse(ConfigurationManager.AppSettings["UserId"]);

            //api.UploadProfileImage(userId, new byte[] {}, "image", CancellationToken.None);
        }


    }
}
