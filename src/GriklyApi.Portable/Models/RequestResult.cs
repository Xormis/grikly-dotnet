using System.Collections.Generic;

namespace Grikly
{
    public class HttpResponse : IHttpResponse
    {
        #region Implementation of IResponseResult

        public bool IsError { get; set; }
        public ErrorResponse Error { get; set; }
        public string ContentType { get; set; }
        public byte[] RawBytes { get; set; }
        public long ContentLength { get; set; }

        #endregion
    }
    public class HttpResponse<T> : IHttpResponse<T>
    {
        public HttpResponse()
        {
            
        }
        public HttpResponse(IHttpResponse responseResult)
        {
            IsError = responseResult.IsError;
            Error = responseResult.Error;
            ContentType = responseResult.ContentType;
            RawBytes = responseResult.RawBytes;
            ContentLength = responseResult.ContentLength;
        }

        #region Implementation of IResponseResult

        public T Data { get; set; }
        public bool IsError { get; set; }
        public ErrorResponse Error { get; set; }
        public string ContentType { get; set; }
        public byte[] RawBytes { get; set; }
        public long ContentLength { get; set; }

        #endregion
    }

    public interface IHttpResponse
    {
        bool IsError { get; set; }
        ErrorResponse Error { get; set; }

        string ContentType { get; set; }

        byte[] RawBytes { get; set; }

        long ContentLength { get; set; }
    }

    public interface IHttpResponse<T> : IHttpResponse
    {
        T Data { get; set; }
    }

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest()
        {
            Headers = new Dictionary<string, string>();
            Method = "GET";
            Body = string.Empty;
        }

        public string Url { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public string Body { get; set; }
        public string Method { get; set; }
        public string ContentType { get; set; }
    }

    public interface IHttpRequest
    {
        string Url { get; set; }
        Dictionary<string, string> Headers { get; set; }
        string Body { get; set; }
        string Method { get; set; }
        string ContentType { get; set; }
    }
}