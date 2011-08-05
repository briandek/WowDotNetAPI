using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class Auction
    {
        [DataMember(Name = "auc")]
        public int Id { get; set; }
        [DataMember(Name = "item")]
        public ulong ItemId { get; set; }
        [DataMember(Name = "owner")]
        public string Owner { get; set; }
        [DataMember(Name = "bid")]
        public ulong Bid { get; set; }
        [DataMember(Name = "buyout")]
        public ulong Buyout { get; set; }
        [DataMember(Name = "quantity")]
        public uint Quantity { get; set; }
    }
}