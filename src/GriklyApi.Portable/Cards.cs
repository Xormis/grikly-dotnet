// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cards.cs" company="">
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
        ///     Creates the card.
        /// </summary>
        /// <param name="card">
        ///     The card.
        /// </param>
        /// <param name="token">
        ///     The token.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public Task<GriklyHttpResponseMessage<object>> CreateCard(Card card, CancellationToken token)
        {
            string path = "v1/Cards";
            return
                Execute<object>(
                    new HttpRequestMessage(HttpMethod.Post, path)
                    {
                        Content =
                            new StringContent(
                                JsonConvert.SerializeObject(card),
                                Encoding.UTF8,
                                "application/json"),
                    },
                    token);
        }

        /// <summary>
        ///     Deletes the card.
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
        public Task<GriklyHttpResponseMessage<Card>> DeleteCard(Guid id, CancellationToken token)
        {
            string path = string.Format("v1/Cards/{0}", id);
            return Execute<Card>(new HttpRequestMessage(HttpMethod.Delete, path), token);
        }

        /// <summary>
        ///     Gets the card.
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
        public Task<GriklyHttpResponseMessage<Card>> GetCard(Guid id, CancellationToken token)
        {
            string path = string.Format("v1/Cards/{0}", id);
            return Execute<Card>(new HttpRequestMessage(HttpMethod.Get, path), token);
        }

        /// <summary>
        ///     Sends the card.
        /// </summary>
        /// <param name="id">
        ///     The id.
        /// </param>
        /// <param name="model">
        ///     The model.
        /// </param>
        /// <param name="token">
        ///     The token.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public Task<GriklyHttpResponseMessage<Card>> SendCard(Guid id, SendCardModel model, CancellationToken token)
        {
            string path = string.Format("v1/Cards/{0}/", id);
            return Execute<Card>(
                new HttpRequestMessage(HttpMethod.Delete, path), token);
        }

        /// <summary>
        ///     Updates the card.
        /// </summary>
        /// <param name="card">
        ///     The card.
        /// </param>
        /// <param name="token">
        ///     The token.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public Task<GriklyHttpResponseMessage<Card>> UpdateCard(Card card, CancellationToken token)
        {
            string path = string.Format("v1/Cards/{0}", card.CardId);
            return
                Execute<Card>(
                    new HttpRequestMessage(HttpMethod.Put, path)
                    {
                        Content =
                            new StringContent(
                                JsonConvert.SerializeObject(card),
                                Encoding.UTF8,
                                "application/json"),
                    },
                    token);
        }

        #endregion
    }
}