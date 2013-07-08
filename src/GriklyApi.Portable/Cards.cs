using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Grikly.Models;
using System;
using Newtonsoft.Json;

namespace Grikly
{
    public partial class GriklyApi
    {
        /// <summary>
        /// Gets the card.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public Task<IHttpResponse<Card>> GetCard(int id, CancellationToken token)
        {
            string path = string.Format("Cards/{0}", id);
            return Execute<Card>(new HttpRequest
                               {
                                   Method = "GET"
                               }, path,token);
        }

        /// <summary>
        /// Creates the card.
        /// </summary>
        /// <param name="card">The card.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public Task<IHttpResponse<Card>> CreateCard(Card card, CancellationToken token)
        {
            string path = "Cards";
            return Execute<Card>(new HttpRequest
                        {
                            Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(card)),
                            Method = "POST",
                            ContentType = "application/json"
                        }, path,token );
        }

        /// <summary>
        /// Updates the card.
        /// </summary>
        /// <param name="card">The card.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public Task<IHttpResponse<Card>> UpdateCard(Card card, CancellationToken token)
        {
            string path = string.Format("Cards/{0}", card.CardId);
            return Execute<Card>(new HttpRequest
            {
                Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(card)),
                Method = "PUT",
                ContentType = "application/json"
            }, path,token);
        }

        /// <summary>
        /// Deletes the card.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public Task<IHttpResponse<Card>> DeleteCard(int id, CancellationToken token)
        {
            string path = string.Format("Cards/{0}", id);
            return Execute<Card>(new HttpRequest
            {
                Method = "DELETE",
                ContentType = "application/json"
            }, path, token);
        }

        /// <summary>
        /// Sends the card.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="model">The model.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public Task<IHttpResponse<Card>> SendCard(int id, SendCardModel model, CancellationToken token)
        {
            string path = string.Format("Cards/{0}/", id);
            return Execute<Card>(new HttpRequest
            {
                Method = "DELETE",
                ContentType = "application/json"
            }, path, token);
        }
    }
}