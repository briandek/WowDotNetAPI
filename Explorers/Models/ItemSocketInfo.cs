using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class ItemSocketInfo
    {
        [DataMember(Name="sockets")]
        public IEnumerable<ItemSocket> Sockets { get; set; }  
    }
}
