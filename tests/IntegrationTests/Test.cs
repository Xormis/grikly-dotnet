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

        //[Test]
        //public void test()
        //{
        //    GriklyApi api = new GriklyApi("");

        //    var completion = new ManualResetEvent(false);

        //    api.Execute(new HttpRequest
        //                    {
        //                        Body = "LOL",
        //                        Method = "POST"
        //                    }, "Cards", (result) =>
        //                                          {
        //                                              completion.Set();
        //                                          });
        //    completion.WaitOne();
        //}

        //[Test]
        //public void GET_User_By_Id_Returns_Model()
        //{
        //    GriklyApi api = new GriklyApi("");

        //    var completion = new ManualResetEvent(false);
        //    api.AddValidUserCredentials(2, "");
        //    api.UpdateCard(new Card
        //                       {
        //                           CardId = 2,
        //                           FirstName = "Shawn",
        //                           LastName = "Mclean",
        //                           CellNumber = "4354470",
        //                           Company = "NCU"
        //                       }, (result) =>
        //    {
        //        completion.Set();
        //    });
        //    completion.WaitOne();
        //}

        //[Test]
        //public void Delete()
        //{
        //    GriklyApi api = new GriklyApi("");

        //    var completion = new ManualResetEvent(false);
        //    api.AddValidUserCredentials(2, "");
        //    api.DeleteCard(2, (result) =>
        //    {
        //        completion.Set();
        //    });
        //    completion.WaitOne();
        //}

        //[Test]
        //public void Login()
        //{
        //    GriklyApi api = new GriklyApi("");

        //    var completion = new ManualResetEvent(false);
        //    api.GetValidUser(new LoginModel
        //                         {
        //                             Email = "shawn@xormis.com",
        //                             Password = "test"
        //                         }, (result) =>
        //    {
        //        completion.Set();
        //    });
        //    completion.WaitOne();
        //}

        //[Test]
        //public void Register()
        //{
        //    GriklyApi api = new GriklyApi("");

        //    var completion = new ManualResetEvent(false);
        //    api.Register(new RegisterModel
        //                     {
        //                         Email = "shawn@xormis.com",
        //                         FirstName = "Shawn",
        //                         LastName = "Mclean",
        //                         Password = "test"
        //                     }, (result) =>
        //    {
        //        completion.Set();
        //    });
        //    completion.WaitOne();
        //}

        //[Test]
        //public void EmailExist()
        //{
        //    GriklyApi api = new GriklyApi("");

        //    var completion = new ManualResetEvent(false);
        //    api.EmailExist("@xormis.com", (result) =>
        //    {
        //        completion.Set();
        //    });
        //    completion.WaitOne();
        //}
    }
}
