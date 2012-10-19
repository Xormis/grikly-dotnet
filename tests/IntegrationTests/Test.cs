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
    public class lol
    {
        public string test { get; set; }
        public string test1 { get; set; }
    }
    [TestFixture]
    public class Test
    {

        [Test]
        public void test()
        {
            GriklyApi api = new GriklyApi("");

            var completion = new ManualResetEvent(false);

            api.Execute<Card>("Cards/1/", "GET", (result) =>
                                                  {
                                                      completion.Set();
                                                  });
            completion.WaitOne();
        }
    }
}
