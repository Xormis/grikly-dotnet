using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;

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
            string l = "{test2:\"lol\", test1:\"val for test1\"}";

            lol fsdfs = JsonConvert.DeserializeObject<lol>(l);

        }
    }
}
