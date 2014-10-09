using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GriklyApi.Helpers;
using GriklyApi.Models;
using GriklyApi.Models.Events;
using Newtonsoft.Json;

namespace GriklyApi
{
    public partial class GriklyClient
    {
        /// <summary>
        ///     Creates the event.
        /// </summary>
        /// <param name="eventModel">The event model.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public Task<GriklyHttpResponseMessage<CreateEventResponse>> CreateEvent(EventModel eventModel,
            CancellationToken token)
        {
            string path = "v1/Events";
            return
                Execute<CreateEventResponse>(
                    new HttpRequestMessage(HttpMethod.Post, path)
                    {
                        Content =
                            new StringContent(
                                JsonConvert.SerializeObject(eventModel),
                                Encoding.UTF8,
                                "application/json"),
                    },
                    token);
        }

        /// <summary>
        ///     Gets the event by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public Task<GriklyHttpResponseMessage<EventModel>> GetEventById(Guid id, CancellationToken token)
        {
            string path = string.Format("v1/Events/{0}", id);
            return Execute<EventModel>(new HttpRequestMessage(HttpMethod.Get, path), token);
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<GriklyHttpResponseMessage<PagingModel<EventModel>>> GetOwnedEvents(GetEventsRequest request,
            CancellationToken token)
        {
            string path = string.Format("v1/Events/Owned?{0}", request.ToQueryString());
            return Execute<PagingModel<EventModel>>(new HttpRequestMessage(HttpMethod.Get, path), token);
        }
    }
}