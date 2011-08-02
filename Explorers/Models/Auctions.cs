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
        [DataMember(Name = "horde")]
        public AuctionHouseSide Horde { get; set; }
        [DataMember(Name = "alliance")]
        public AuctionHouseSide Alliance { get; set; }
        [DataMember(Name = "neutral")]
        public AuctionHouseSide Neutral { get; set; }
    }
}
