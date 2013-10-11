// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequestResult.cs" company="">
//   
// </copyright>
// <summary>
//   The http response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Grikly
{
    using System.Collections.Generic;

    /// <summary>
    /// The http response.
    /// </summary>
    public class HttpResponse : IHttpResponse
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the content length.
        /// </summary>
        public long ContentLength { get; set; }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        public ErrorResponse Error { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is error.
        /// </summary>
        public bool IsError { get; set; }

        /// <summary>
        /// Gets or sets the raw bytes.
        /// </summary>
        public byte[] RawBytes { get; set; }

        #endregion
    }

    /// <summary>
    /// The http response.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class HttpResponse<T> : IHttpResponse<T>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponse{T}"/> class.
        /// </summary>
        public HttpResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponse{T}"/> class.
        /// </summary>
        /// <param name="responseResult">
        /// The response result.
        /// </param>
        public HttpResponse(IHttpResponse responseResult)
        {
            this.IsError = responseResult.IsError;
            this.Error = responseResult.Error;
            this.ContentType = responseResult.ContentType;
            this.RawBytes = responseResult.RawBytes;
            this.ContentLength = responseResult.ContentLength;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the content length.
        /// </summary>
        public long ContentLength { get; set; }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        public ErrorResponse Error { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is error.
        /// </summary>
        public bool IsError { get; set; }

        /// <summary>
        /// Gets or sets the raw bytes.
        /// </summary>
        public byte[] RawBytes { get; set; }

        #endregion
    }

    /// <summary>
    /// The HttpResponse interface.
    /// </summary>
    public interface IHttpResponse
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the content length.
        /// </summary>
        long ContentLength { get; set; }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        ErrorResponse Error { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is error.
        /// </summary>
        bool IsError { get; set; }

        /// <summary>
        /// Gets or sets the raw bytes.
        /// </summary>
        byte[] RawBytes { get; set; }

        #endregion
    }

    /// <summary>
    /// The HttpResponse interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IHttpResponse<T> : IHttpResponse
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        T Data { get; set; }

        #endregion
    }

    /// <summary>
    /// The http request.
    /// </summary>
    public class HttpRequest : IHttpRequest
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequest"/> class.
        /// </summary>
        public HttpRequest()
        {
            this.Headers = new Dictionary<string, string>();
            this.Method = "GET";
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        public byte[] Body { get; set; }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the headers.
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        public string Url { get; set; }

        #endregion
    }

    /// <summary>
    /// The HttpRequest interface.
    /// </summary>
    public interface IHttpRequest
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        byte[] Body { get; set; }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the headers.
        /// </summary>
        Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        string Method { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        string Url { get; set; }

        #endregion
    }
}