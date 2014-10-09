// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Contacts.cs" company="">
//   
// </copyright>
// <summary>
//   The grikly api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Grikly;
using GriklyApi.Models;
using Newtonsoft.Json;

namespace GriklyApi
{
    /// <summary>
    ///     The grikly api.
    /// </summary>
    public partial class GriklyClient : IGriklyClient
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Creates the contact.
        /// </summary>
        /// <param name="contact">
        ///     The contact.
        /// </param>
        /// <param name="token">
        ///     The token.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public Task<GriklyHttpResponseMessage<Card>> CreateContact(Contact contact, CancellationToken token)
        {
            string path = "v1/Contacts";
            return
                Execute<Card>(
                    new HttpRequestMessage(HttpMethod.Post, path)
                    {
                        Content =
                            new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json"),
                    }, token);
        }

        /// <summary>
        ///     Deletes the contact.
        /// </summary>
        /// <param name="id">
        ///     The id.
        /// </param>
        /// <param name="token">
        ///     The token.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public Task<GriklyHttpResponseMessage<Card>> DeleteContact(Guid id, CancellationToken token)
        {
            string path = string.Format("v1/Contacts/{0}", id);
            return Execute<Card>(new HttpRequestMessage(HttpMethod.Delete, path), token);
        }

        /// <summary>
        ///     The get contacts.
        /// </summary>
        /// <param name="searchText">
        ///     The search text.
        /// </param>
        /// <param name="page">
        ///     The page.
        /// </param>
        /// <param name="pageSize">
        ///     The page size.
        /// </param>
        /// <param name="token">
        ///     The token.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public Task<GriklyHttpResponseMessage<PagingModel<Card>>> GetContacts(
            string searchText,
            int page,
            int pageSize,
            CancellationToken token)
        {
            string path = string.Format("v1/Contacts?SearchText={0}&Page={1}&PageSize={2}", searchText, page, pageSize);
            return Execute<PagingModel<Card>>(new HttpRequestMessage(HttpMethod.Get, path), token);
        }

        /// <summary>
        ///     Updates the contact.
        /// </summary>
        /// <param name="contact">
        ///     The contact.
        /// </param>
        /// <param name="token">
        ///     The token.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public Task<GriklyHttpResponseMessage<Card>> UpdateContact(Contact contact, CancellationToken token)
        {
            string path = string.Format("v1/Contacts/{0}", contact.CardId);
            return
                Execute<Card>(
                    new HttpRequestMessage(HttpMethod.Put, path)
                    {
                        Content =
                            new StringContent(
                                JsonConvert.SerializeObject(contact),
                                Encoding.UTF8,
                                "application/json"),
                    },
                    token);
        }

        #endregion
    }
}