using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Grikly;
using Grikly.Models;
using Newtonsoft.Json;

namespace Grikly
{
    public partial class GriklyApi
    {
        public void GetContacts(string searchText, int page, Action<IHttpResponse<IList<Card>>> callback)
        {
            string path = string.Format("Contacts?searchText={0}&page={1}", searchText, page);
            Execute(new HttpRequest
            {
                Method = "GET"
            }, path, callback);
        }

        public void CreateContact(Contact contact, Action<IHttpResponse<Card>> callback)
        {
            string path = "Contacts";
            Execute(new HttpRequest
            {
                Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(contact)),
                Method = "POST",
                ContentType = "application/json"
            }, path, callback);
        }

        public void UpdateContact(Contact contact, Action<IHttpResponse<Card>> callback)
        {
            string path = string.Format("Contacts/{0}", contact.CardId);
            Execute(new HttpRequest
            {
                Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(contact)),
                Method = "PUT",
                ContentType = "application/json"
            }, path, callback);
        }
        public void DeleteContact(int id, Action<IHttpResponse<Card>> callback)
        {
            string path = string.Format("Contacts/{0}", id);
            Execute(new HttpRequest
            {
                Method = "DELETE",
                ContentType = "application/json"
            }, path, callback);
        }
    }
}
