using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class RealmsData
    {
        [DataMember(Name = "realms")]
        public IEnumerable<Realm> Realms { get; set; }
    }
}
