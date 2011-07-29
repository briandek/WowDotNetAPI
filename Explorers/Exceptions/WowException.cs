using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Exceptions
{
    public class WowException : Exception, ISerializable
    {
        public WowException(string message, ErrorDetail errorDetail, string url)
            : base(message)
        {
            ErrorDetail = errorDetail;
            Reason = errorDetail.Reason;
            Url = url;
        }

        public ErrorDetail ErrorDetail { get; private set; }
        public string Reason { get; private set; }
        public string Url { get; private set; }

    }
}
