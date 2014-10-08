using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GriklyApi.Models.Events;
using Xunit;

namespace Grikly.Tests.IntegrationTests.Events
{
    public class OwnedEventTests : TestBase
    {
        [Fact(Skip = "Not finished")]
        public async Task Should_Return_Http_Status_Ok_When_Successful()
        {
            var model = new GetEventsRequest(1, 10, "Start DESC");
            var response = await Client.GetOwnedEvents(model, CancellationToken.None);

            var content = await response.Message.Content.ReadAsStringAsync();
            Assert.NotNull(content);
            Assert.Equal(HttpStatusCode.OK, response.Message.StatusCode);
        }
    }
}
