using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class Auction
    {
        [DataMember(Name = "auc")]
        public int Id { get; set; }
        [DataMember(Name = "item")]
        public long ItemId { get; set; }
        [DataMember(Name = "owner")]
        public string Owner { get; set; }
        [DataMember(Name = "bid")]
        public long Bid { get; set; }
        [DataMember(Name = "buyout")]
        public long Buyout { get; set; }
        [DataMember(Name = "quantity")]
        public int Quantity { get; set; }
        [DataMember(Name = "timeLeft")]
        public string TimeLeft { get; set; }
    }
}