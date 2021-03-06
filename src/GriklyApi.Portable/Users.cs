﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Users.cs" company="">
//   
// </copyright>
// <summary>
//   The grikly api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Grikly;
using GriklyApi.Models;

namespace GriklyApi
{
    /// <summary>
    ///     The grikly api.
    /// </summary>
    public partial class GriklyClient : IGriklyClient
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Gets the user.
        /// </summary>
        /// <param name="id">
        ///     The id.
        /// </param>
        /// <param name="token">
        ///     The token.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public Task<GriklyHttpResponseMessage<User>> GetUser(Guid id, CancellationToken token)
        {
            string path = string.Format("Users/{0}", id);
            return Execute<User>(new HttpRequestMessage(HttpMethod.Get, path), token);
        }

        #endregion
    }
}