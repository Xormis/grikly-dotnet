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
                            Body = JsonConvert.SerializeObject(card),
                            Method = "POST",
                            ContentType = "application/json"
                        }, path, callback );
        }

        public Card UpdateCard(Card card)
        {
            throw new NotImplementedException();
        }

        public Card DeleteCard(int cardId)
        {
            throw new NotImplementedException();
        }
    }
}