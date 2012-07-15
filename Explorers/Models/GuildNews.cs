using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class GuildNews
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "character")]
        public string Character { get; set; }

        [DataMember(Name = "timestamp")]
        public long Timestamp { get; set; }

        [DataMember(Name = "itemId")]
        public int ItemID { get; set; }

        [DataMember(Name = "achievement")]
        public AchievementInfo Achievement { get; set; }

        [DataMember(Name = "levelUp")]
        public int LevelUp { get; set; }

    }
}
