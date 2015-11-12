using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class Auctions
    {
        [DataMember(Name = "realm")]
        public Realm Realm { get; set; }
        [DataMember(Name = "auctions")]
        public IEnumerable<Auction> CurrentAuctions { get; set; }
    }
}
