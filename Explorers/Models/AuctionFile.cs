using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class AuctionFile
    {
        [DataMember(Name = "url")]
        public string URL { get; set; }
        [DataMember(Name = "lastModified")]
        public long LastModified { get; set; }
    }
}
