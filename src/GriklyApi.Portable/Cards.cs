using System.Text;
using Grikly.Models;
using System;
using Newtonsoft.Json;

namespace Grikly
{
    public partial class GriklyApi
    {
        public void GetCard(int id, Action<IHttpResponse<Card>> callback)
        {
            string path = string.Format("Cards/{0}", id);
            Execute(new HttpRequest
            {
                Method = "GET"
            }, path, callback);
        }

        public void CreateCard(Card card, Action<IHttpResponse<Card>> callback)
        {
            string path = "Cards";
            Execute(new HttpRequest
                        {
                            Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(card)),
                            Method = "POST",
                            ContentType = "application/json"
                        }, path, callback );
        }

        public void UpdateCard(Card card, Action<IHttpResponse<Card>> callback)
        {
            string path = string.Format("Cards/{0}", card.CardId);
            Execute(new HttpRequest
            {
                Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(card)),
                Method = "PUT",
                ContentType = "application/json"
            }, path, callback);
        }

        public void DeleteCard(int id, Action<IHttpResponse<Card>> callback)
        {
            string path = string.Format("Cards/{0}", id);
            Execute(new HttpRequest
            {
                Method = "DELETE",
                ContentType = "application/json"
            }, path, callback);
        }
    }
}