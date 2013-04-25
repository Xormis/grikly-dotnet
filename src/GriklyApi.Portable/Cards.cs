using System.Text;
using System.Threading.Tasks;
using Grikly.Models;
using System;
using Newtonsoft.Json;

namespace Grikly
{
    public partial class GriklyApi
    {
        public Task<IHttpResponse<Card>> GetCard(int id)
        {
            string path = string.Format("Cards/{0}", id);
            return Execute<Card>(new HttpRequest
                               {
                                   Method = "GET"
                               }, path);
        }

        public Task<IHttpResponse<Card>> CreateCard(Card card)
        {
            string path = "Cards";
            return Execute<Card>(new HttpRequest
                        {
                            Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(card)),
                            Method = "POST",
                            ContentType = "application/json"
                        }, path );
        }

        public Task<IHttpResponse<Card>> UpdateCard(Card card)
        {
            string path = string.Format("Cards/{0}", card.CardId);
            return Execute<Card>(new HttpRequest
            {
                Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(card)),
                Method = "PUT",
                ContentType = "application/json"
            }, path);
        }

        public Task<IHttpResponse<Card>> DeleteCard(int id)
        {
            string path = string.Format("Cards/{0}", id);
            return Execute<Card>(new HttpRequest
            {
                Method = "DELETE",
                ContentType = "application/json"
            }, path);
        }
    }
}