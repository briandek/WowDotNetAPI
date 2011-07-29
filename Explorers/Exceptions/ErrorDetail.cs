using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Exceptions
{
    [DataContract]
    public class ErrorDetail
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "reason")]
        public string Reason { get; set; }
    }
}
