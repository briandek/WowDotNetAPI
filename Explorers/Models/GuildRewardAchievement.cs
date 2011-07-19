using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class GuildRewardAchievement
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "points")]
        public int Points { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "reward")]
        public string Reward { get; set; }

        [DataMember(Name = "rewardItem")]
        public GuildRewardItem RewardItem { get; set; }

    }
}
