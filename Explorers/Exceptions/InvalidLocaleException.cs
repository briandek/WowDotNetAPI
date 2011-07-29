using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Exceptions
{
    public class InvalidLocaleException : Exception, ISerializable
    {
        public InvalidLocaleException(string message, Region region, Locale locale)
            : base(message)
        {
            Region = region;
            Locale = locale;
        }

        public Region Region { get; private set; }
        public Locale Locale { get; private set; }

    }
}
