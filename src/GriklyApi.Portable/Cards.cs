// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cards.cs" company="">
//   
// </copyright>
// <summary>
//   The grikly api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Grikly
{
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using Grikly.Models;

    using Newtonsoft.Json;

    /// <summary>
    /// The grikly api.
    /// </summary>
    public partial class GriklyApi
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
        public Task<IHttpResponse<Card>> CreateCard(Card card, CancellationToken token)
        {
            string path = "Cards";
            return
                this.Execute<Card>(
                    new HttpRequest
                        {
                            Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(card)), 
                            Method = "POST", 
                            ContentType = "application/json"
                        }, 
                    path, 
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
        public Task<IHttpResponse<Card>> DeleteCard(int id, CancellationToken token)
        {
            string path = string.Format("Cards/{0}", id);
            return this.Execute<Card>(
                new HttpRequest { Method = "DELETE", ContentType = "application/json" }, 
                path, 
                token);
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
        public Task<IHttpResponse<Card>> GetCard(int id, CancellationToken token)
        {
            string path = string.Format("Cards/{0}", id);
            return this.Execute<Card>(new HttpRequest { Method = "GET" }, path, token);
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
        public Task<IHttpResponse<Card>> SendCard(int id, SendCardModel model, CancellationToken token)
        {
            string path = string.Format("Cards/{0}/", id);
            return this.Execute<Card>(
                new HttpRequest { Method = "DELETE", ContentType = "application/json" }, 
                path, 
                token);
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
            string path = string.Format("Cards/{0}", card.CardId);
            return
                this.Execute<Card>(
                    new HttpRequest
                        {
                            Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(card)), 
                            Method = "PUT", 
                            ContentType = "application/json"
                        }, 
                    path, 
                    token);
        }

        #endregion
    }
}