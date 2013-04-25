using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grikly;
using Grikly.Models;
using Newtonsoft.Json;

namespace Grikly
{
    public partial class GriklyApi
    {
        public Task<IHttpResponse<IList<Card>>> GetContacts(string searchText, int page)
        {
            string path = string.Format("Contacts?searchText={0}&page={1}", searchText, page);
            return Execute<IList<Card>>(new HttpRequest
            {
                Method = "GET"
            }, path);
        }

        public Task<IHttpResponse<Card>> CreateContact(Contact contact)
        {
            string path = "Contacts";
            return Execute<Card>(new HttpRequest
            {
                Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(contact)),
                Method = "POST",
                ContentType = "application/json"
            }, path);
        }

        public Task<IHttpResponse<Card>> UpdateContact(Contact contact)
        {
            string path = string.Format("Contacts/{0}", contact.CardId);
            return Execute<Card>(new HttpRequest
            {
                Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(contact)),
                Method = "PUT",
                ContentType = "application/json"
            }, path);
        }
        public Task<IHttpResponse<Card>> DeleteContact(int id)
        {
            string path = string.Format("Contacts/{0}", id);
            return Execute<Card>(new HttpRequest
            {
                Method = "DELETE",
                ContentType = "application/json"
            }, path);
        }
    }
}
