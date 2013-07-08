using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Grikly;
using Grikly.Models;
using Newtonsoft.Json;

namespace Grikly
{
    public partial class GriklyApi
    {
        /// <summary>
        /// Gets the contacts.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="page">The page.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public Task<IHttpResponse<IList<Card>>> GetContacts(string searchText, int page, CancellationToken token)
        {
            string path = string.Format("Contacts?searchText={0}&page={1}", searchText, page);
            return Execute<IList<Card>>(new HttpRequest
            {
                Method = "GET"
            }, path, token);
        }

        /// <summary>
        /// Creates the contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public Task<IHttpResponse<Card>> CreateContact(Contact contact, CancellationToken token)
        {
            string path = "Contacts";
            return Execute<Card>(new HttpRequest
            {
                Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(contact)),
                Method = "POST",
                ContentType = "application/json"
            }, path, token);
        }

        /// <summary>
        /// Updates the contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public Task<IHttpResponse<Card>> UpdateContact(Contact contact, CancellationToken token)
        {
            string path = string.Format("Contacts/{0}", contact.CardId);
            return Execute<Card>(new HttpRequest
            {
                Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(contact)),
                Method = "PUT",
                ContentType = "application/json"
            }, path, token);
        }
        /// <summary>
        /// Deletes the contact.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public Task<IHttpResponse<Card>> DeleteContact(int id, CancellationToken token)
        {
            string path = string.Format("Contacts/{0}", id);
            return Execute<Card>(new HttpRequest
            {
                Body = new byte[0],
                Method = "DELETE",
                ContentType = "application/json"
            }, path, token);
        }
    }
}
