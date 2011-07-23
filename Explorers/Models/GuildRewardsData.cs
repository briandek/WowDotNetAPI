using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class GuildRewardsData
    {
        [DataMember(Name="rewards")]
        public IEnumerable<GuildRewardInfo> Rewards { get; set; }
    }
}
