using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class AchievementInfo
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

        [DataMember(Name = "rewardItems")]
        public IEnumerable<AchievementReward> RewardItems { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "criteria")]
        public IEnumerable<AchievementCriteria> Criteria { get; set; }

        [DataMember(Name = "accountWide")]
        public bool AccountWide { get; set; }

    }
}
