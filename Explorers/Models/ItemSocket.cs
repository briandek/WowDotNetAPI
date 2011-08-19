using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class ItemSocket
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}
