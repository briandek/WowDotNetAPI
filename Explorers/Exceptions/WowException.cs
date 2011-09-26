using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Net;

namespace WowDotNetAPI.Exceptions
{
    public class WowException : Exception, ISerializable
    {
        public WowException(string message, ErrorDetail errorDetail, string url, WebException originalException)
            : base(message)
        {
            ErrorDetail = errorDetail;
            Reason = errorDetail.Reason;
            Url = url;
            OriginalException = originalException;
        }

        public ErrorDetail ErrorDetail { get; private set; }
        public string Reason { get; private set; }
        public string Url { get; private set; }
        public WebException OriginalException { get; private set; }

    }
}
