// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cards.cs" company="">
//   
// </copyright>
// <summary>
//   The grikly api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GriklyApi
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;


    using Grikly;

    using GriklyApi.Models;

    using Newtonsoft.Json;

    /// <summary>
    ///     The grikly api.
    /// </summary>
    public partial class GriklyClient : IGriklyClient
    {
        #region Public Methods and Operators

        /// <summary>
        /// Creates the card.
        /// </summary>
        /// <param name="card">
        /// The card.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<IHttpResponse<object>> CreateCard(Card card, CancellationToken token)
        {
            string path = "v1/Cards";
            return
                this.Execute<object>(
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
        /// Deletes the card.
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
        public Task<IHttpResponse<Card>> DeleteCard(Guid id, CancellationToken token)
        {
            string path = string.Format("v1/Cards/{0}", id);
            return this.Execute<Card>(new HttpRequestMessage(HttpMethod.Delete, path), token);
        }

        /// <summary>
        /// Gets the card.
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
        public Task<IHttpResponse<Card>> GetCard(Guid id, CancellationToken token)
        {
            string path = string.Format("v1/Cards/{0}", id);
            return this.Execute<Card>(new HttpRequestMessage(HttpMethod.Get, path), token);
        }

        /// <summary>
        /// Sends the card.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<IHttpResponse<Card>> SendCard(Guid id, SendCardModel model, CancellationToken token)
        {
            string path = string.Format("v1/Cards/{0}/", id);
            return this.Execute<Card>(
                new HttpRequestMessage(HttpMethod.Delete, path), token);
        }

        /// <summary>
        /// Updates the card.
        /// </summary>
        /// <param name="card">
        /// The card.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<IHttpResponse<Card>> UpdateCard(Card card, CancellationToken token)
        {
            string path = string.Format("v1/Cards/{0}", card.CardId);
            return
                this.Execute<Card>(
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