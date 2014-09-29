using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GriklyApi.Models;
using Xunit;

namespace Grikly.Tests.IntegrationTests.Accounts
{
    public class RegisterUserTests : TestBase
    {
        [Fact(Skip = "Not finalized")]
        public async Task Register_User_Returns_HttpStatus_Created_When_Successful()
        {
            var response = await Client.Register(new RegisterModel
            {
                Email = "grikly-integration@mailinator.com",
                FirstName = "Shawn",
                LastName = "Mclean",
                Password = "testuser"
            }, CancellationToken.None);

            Assert.Equal(HttpStatusCode.OK, response.Message.StatusCode);
        }
    }
}
