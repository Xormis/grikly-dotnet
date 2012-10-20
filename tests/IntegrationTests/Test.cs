using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;
using Grikly.Models;

namespace Grikly.Tests.IntegrationTests
{
    [TestFixture]
    public class Test
    {

        [Test]
        public void test()
        {
            GriklyApi api = new GriklyApi("");

            var completion = new ManualResetEvent(false);

            api.Execute(new HttpRequest
                            {
                                Body = "LOL",
                                Method = "POST"
                            }, "Cards", (result) =>
                                                  {
                                                      completion.Set();
                                                  });
            completion.WaitOne();
        }

        [Test]
        public void GET_User_By_Id_Returns_Model()
        {
            GriklyApi api = new GriklyApi("");

            var completion = new ManualResetEvent(false);

            api.GetUser(1, (result) =>
            {
                completion.Set();
            });
            completion.WaitOne();
        }
    }
}
