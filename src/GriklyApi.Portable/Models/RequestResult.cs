namespace Grikly
{
    public class RequestResult<T> where T: class
    {
        public T Result { get; set; }
        public bool IsError { get; set; }
        public ErrorResponse Error { get; set; }
    }
}