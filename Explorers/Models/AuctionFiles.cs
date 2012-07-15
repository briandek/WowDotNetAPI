using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class AuctionFiles
    {
        [DataMember(Name = "files")]
        public IEnumerable<AuctionFile> Files { get; set; }
    }
}
