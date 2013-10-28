// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Contacts.cs" company="">
//   
// </copyright>
// <summary>
//   The grikly api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Grikly
{
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using global::GriklyApi.Models;

    using Grikly.Models;

    using Newtonsoft.Json;

    /// <summary>
    /// The grikly api.
    /// </summary>
    public partial class GriklyApi
    {
        #region Public Methods and Operators

        /// <summary>
        /// Creates the contact.
        /// </summary>
        /// <param name="contact">
        /// The contact.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<IHttpResponse<Card>> CreateContact(Contact contact, CancellationToken token)
        {
            string path = "Contacts";
            return
                this.Execute<Card>(
                    new HttpRequest
                        {
                            Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(contact)), 
                            Method = "POST", 
                            ContentType = "application/json"
                        }, 
                    path, 
                    token);
        }

        /// <summary>
        /// Deletes the contact.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<IHttpResponse<Card>> DeleteContact(int id, CancellationToken token)
        {
            string path = string.Format("Contacts/{0}", id);
            return
                this.Execute<Card>(
                    new HttpRequest { Body = new byte[0], Method = "DELETE", ContentType = "application/json" }, 
                    path, 
                    token);
        }
        

        public Task<IHttpResponse<PagingModel<Card>>> GetContacts(string searchText, int page, int pageSize, CancellationToken token)
        {
            string path = string.Format("Contacts?SearchText={0}&Page={1}&PageSize={2}", searchText, page, pageSize);
            return this.Execute<PagingModel<Card>>(new HttpRequest { Method = "GET" }, path, token);
        }
        /// <summary>
        /// Updates the contact.
        /// </summary>
        /// <param name="contact">
        /// The contact.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<IHttpResponse<Card>> UpdateContact(Contact contact, CancellationToken token)
        {
            string path = string.Format("Contacts/{0}", contact.CardId);
            return
                this.Execute<Card>(
                    new HttpRequest
                        {
                            Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(contact)), 
                            Method = "PUT", 
                            ContentType = "application/json"
                        }, 
                    path, 
                    token);
        }

        #endregion
    }
}