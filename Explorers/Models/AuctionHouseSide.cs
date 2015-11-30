using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WowDotNetAPI.Models
{
    [DataContract]
    [Obsolete("With Warlords of Draaenor, auction houses are merged. This class only adds convolution.", true)]
    public class AuctionHouseSide
    {
        [DataMember(Name = "auctions")]
        public IEnumerable<Auction> Auctions { get; set; }
    }
}
