using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;

namespace Grikly.Tests.IntegrationTests
{
    [TestFixture]
    public class Test
    {

        //[Test]
        //public void GetCard()
        //{
        //    GriklyApi api = new GriklyApi("");

        //    var completion = new ManualResetEvent(false);

        //    var card = api.GetCard(1);
        //    var lol = card.Result;
        //    completion.WaitOne();
        //}

        ////[Test]
        ////public void GET_User_By_Id_Returns_Model()
        ////{
        ////    GriklyApi api = new GriklyApi("");

        ////    var completion = new ManualResetEvent(false);
        ////    api.AddValidUserCredentials(2, "");
        ////    api.UpdateCard(new Card
        ////                       {
        ////                           CardId = 2,
        ////                           FirstName = "Shawn",
        ////                           LastName = "Mclean",
        ////                           CellNumber = "4354470",
        ////                           Company = "NCU"
        ////                       }, (result) =>
        ////    {
        ////        completion.Set();
        ////    });
        ////    completion.WaitOne();
        ////}

        ////[Test]
        ////public void Delete()
        ////{
        ////    GriklyApi api = new GriklyApi("");

        ////    var completion = new ManualResetEvent(false);
        ////    api.AddValidUserCredentials(2, "");
        ////    api.DeleteCard(2, (result) =>
        ////    {
        ////        completion.Set();
        ////    });
        ////    completion.WaitOne();
        ////}

        //[Test]
        //public void UploadImage()
        //{
        //    GriklyApi api = new GriklyApi("");
        //    api.AddValidUserCredentials("shawn@xormis.com", "testuser");

        //    var completion = new ManualResetEvent(false);

        //    var stream = File.ReadAllBytes("D:/chair.jpe");

        //    api.UploadProfileImage(1, stream, "image/jpeg", (result) =>
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
        //    var t = api.GetValidUser(new LoginModel
        //                         {
        //                             Email = "shawn@xormis.com",
        //                             Password = "testuser"
        //                         });
        //    var lol = t.Result;
        //    completion.WaitOne();
        //}

        //[Test]
        //public void Register()
        //{
        //    GriklyApi api = new GriklyApi("");

        //    var completion = new ManualResetEvent(false);
        //    var t = api.Register(new RegisterModel
        //                     {
        //                         Email = "shawn@xormis.com",
        //                         FirstName = "Shawn",
        //                         LastName = "Mclean",
        //                         Password = "test"
        //                     });
        //    completion.WaitOne();
        //}

        ////[Test]
        ////public void EmailExist()
        ////{
        ////    GriklyApi api = new GriklyApi("");

        ////    var completion = new ManualResetEvent(false);
        ////    api.EmailExist("@xormis.com", (result) =>
        ////    {
        ////        completion.Set();
        ////    });
        ////    completion.WaitOne();
        ////}

        //[Test]
        //public void CreateCard()
        //{
        //    GriklyApi api = new GriklyApi("");
        //    api.AddValidUserCredentials("","testuser");
        //    var completion = new ManualResetEvent(false);
        //    api.CreateCard(new Card
        //    {
        //        Email = "shawn@xormis.com",
        //        FirstName = "Shawn",
        //        LastName = "Mclean",
        //        CompanyAddress = "Appleton"
        //    });
        //    completion.WaitOne();
        //}

        //[Test]
        //public void CetContacts()
        //{
        //    GriklyApi api = new GriklyApi("");
        //    api.AddValidUserCredentials("shawn@xormis.com", "testuser");
        //    var completion = new ManualResetEvent(false);
        //    api.GetContacts("", 1);
        //    completion.WaitOne();
        //}
    }
}
