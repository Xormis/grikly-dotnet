using Grikly;
using Grikly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            GriklyApi api = new GriklyApi("");
            api.GetValidUser(new LoginModel
            {
                Email = "shawn@xormis.com",
                Password = "testuser"
            }, (u) =>
            {
                Console.Write("");
            });
            //api.AddValidUserCredentials("test@test.com", "testuser");
            //api.CreateCard(new Card
            //{
            //    Email = "shawn@xormis.com",
            //    FirstName = "Shawn",
            //    LastName = "Mclean",
            //    CompanyAddress = "Appleton"
            //}, (result) =>
            //{
            //    Console.Write("");
            //});
            Console.ReadLine();
        }
    }
}
