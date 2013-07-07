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
        public Task<IHttpResponse<Card>> GetCard(int id, CancellationToken token)
        {
            string path = string.Format("Cards/{0}", id);
            return Execute<Card>(new HttpRequest
                               {
                                   Method = "GET"
                               }, path,token);
        }

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

        public Task<IHttpResponse<Card>> DeleteCard(int id, CancellationToken token)
        {
            string path = string.Format("Cards/{0}", id);
            return Execute<Card>(new HttpRequest
            {
                Method = "DELETE",
                ContentType = "application/json"
            }, path, token);
        }

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