using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GriklyApi.Models;
using Newtonsoft.Json;

namespace GriklyApi
{
    public partial class GriklyClient
    {

        /// <summary>
        /// Creates the event.
        /// </summary>
        /// <param name="eventModel">The event model.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public Task<IHttpResponse> CreateEvent(EventModel eventModel, CancellationToken token)
        {
            string path = "v1/Events";
            return
                this.Execute(
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
    }
}
