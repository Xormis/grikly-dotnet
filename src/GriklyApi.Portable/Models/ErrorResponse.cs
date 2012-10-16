using System.Net;

namespace Grikly
{
    public class ErrorResponse
    {
        public HttpStatusCode HttpStatusCode;
        public ErrorMessage Message;
    }
}