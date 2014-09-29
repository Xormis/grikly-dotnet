using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GriklyApi.Models.Events;
using Xunit;

namespace Grikly.Tests.IntegrationTests.Events
{
    public class CreateEventTests : TestBase
    {
        [Fact]
        public async Task Should_Return_Http_Status_Created_With_Id_When_Successful()
        {
            var model = new EventModel
            {
                Title = "Test",
                Start = DateTime.Now.AddDays(1),
                End = DateTime.Now.AddDays(2)
            };
            var response = await Client.CreateEvent(model, CancellationToken.None);
        }
    }
}
