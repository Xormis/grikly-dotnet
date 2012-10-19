namespace Grikly
{
    public class ResponseResult : IResponseResult
    {
        #region Implementation of IResponseResult

        public bool IsError { get; set; }
        public ErrorResponse Error { get; set; }
        public string ContentType { get; set; }
        public byte[] RawBytes { get; set; }
        public long ContentLength { get; set; }

        #endregion
    }
    public class ResponseResult<T> : IResponseResult<T> where T : class
    {
        public ResponseResult()
        {
            
        }
        public ResponseResult(IResponseResult responseResult)
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

    public interface IResponseResult
    {
        bool IsError { get; set; }
        ErrorResponse Error { get; set; }

        string ContentType { get; set; }

        byte[] RawBytes { get; set; }

        long ContentLength { get; set; }
    }

    public interface IResponseResult<T> : IResponseResult
    {
        T Data { get; set; }
    }
}