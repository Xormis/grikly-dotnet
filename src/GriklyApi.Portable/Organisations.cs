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
    /// <summary>
    /// 
    /// </summary>
    public partial class GriklyClient
    {
        /// <summary>
        /// Creates the organisation.
        /// </summary>
        /// <param name="organisationModel">The organisation model.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public Task<GriklyHttpResponseMessage<CreateOrganisationResponse>> CreateOrganisation(OrganisationModel organisationModel, CancellationToken token)
        {
            string path = "v1/Organisations";
            return
                Execute<CreateOrganisationResponse>(
                    new HttpRequestMessage(HttpMethod.Post, path)
                    {
                        Content =
                            new StringContent(
                                JsonConvert.SerializeObject(organisationModel),
                                Encoding.UTF8,
                                "application/json"),
                    },
                    token);
        }
    }
}
