// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utilities.cs" company="">
//   
// </copyright>
// <summary>
//   The http web response data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Grikly
{
    using System;
    using System.Net;

    using GriklyApi.Models;

    /// <summary>
    /// The http web response data.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class HttpWebResponseData<T>
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the data.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        ///     Gets or sets the response.
        /// </summary>
        public HttpWebResponse Response { get; set; }

        #endregion
    }

    /// <summary>
    ///     The http web request data.
    /// </summary>
    public class HttpWebRequestData
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the data.
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        ///     Gets or sets the request.
        /// </summary>
        public HttpWebRequest Request { get; set; }

        /// <summary>
        ///     Gets or sets the response callback.
        /// </summary>
        public Action<IHttpResponse> ResponseCallback { get; set; }

        #endregion
    }

    /// <summary>
    ///     The exception event args.
    /// </summary>
    public class ExceptionEventArgs : EventArgs
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionEventArgs"/> class.
        /// </summary>
        /// <param name="ex">
        /// The ex.
        /// </param>
        public ExceptionEventArgs(Exception ex)
        {
            this.ExceptionInfo = ex;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the exception info.
        /// </summary>
        public Exception ExceptionInfo { get; set; }

        #endregion
    }

    /// <summary>
    /// The event args.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class EventArgs<T> : EventArgs
    {
        #region Fields

        /// <summary>
        ///     The event data.
        /// </summary>
        private readonly T eventData;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EventArgs{T}"/> class.
        /// </summary>
        /// <param name="eventData">
        /// The event data.
        /// </param>
        public EventArgs(T eventData)
        {
            this.eventData = eventData;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the event data.
        /// </summary>
        public T EventData
        {
            get
            {
                return this.eventData;
            }
        }

        #endregion
    }
}