using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Grikly;

namespace Grikly
{
    public class HttpWebResponseData<T>
    {
        public HttpWebResponse Response { get; set; }
        public T Data { get; set; }
    }

    public class HttpWebRequestData
    {
        public HttpWebRequest Request { get; set; }
        public Action<IHttpResponse> ResponseCallback { get; set; }
        public byte[] Data { get; set; }
    }

    public class ExceptionEventArgs : EventArgs
    {
        public Exception ExceptionInfo { get; set; }

        public ExceptionEventArgs(Exception ex)
        {
            ExceptionInfo = ex;
        }
    }

    public class EventArgs<T> : EventArgs
    {
        private T eventData;

        public EventArgs(T eventData)
        {
            this.eventData = eventData;
        }

        public T EventData
        {
            get
            {
                return eventData;
            }
        }
    }
}
