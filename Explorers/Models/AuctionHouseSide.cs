using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class AuctionHouseSide
    {
        [DataMember(Name = "auctions")]
        public IEnumerable<Auction> Auctions { get; set; }
    }
}
