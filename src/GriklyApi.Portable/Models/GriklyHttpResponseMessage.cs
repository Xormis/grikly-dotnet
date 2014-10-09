using System.Net.Http;

namespace GriklyApi.Models
{
    public class GriklyHttpResponseMessage<T> : GriklyHttpResponseMessage
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Net.Http.HttpResponseMessage" /> class.
        /// </summary>
        public GriklyHttpResponseMessage(HttpResponseMessage message)
            : base(message)
        {
        }

        public T SerializedContent { get; set; }
    }

    public class GriklyHttpResponseMessage
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Net.Http.HttpResponseMessage" /> class.
        /// </summary>
        public GriklyHttpResponseMessage(HttpResponseMessage message)
        {
            Message = message;
        }

        /// <summary>
        ///     Gets or sets the error.
        /// </summary>
        public ErrorMessage ErrorMessage { get; set; }

        public HttpResponseMessage Message { get; set; }
    }
}