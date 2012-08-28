using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class CharacterFeed
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "timestamp")]
        public long Timestamp { get; set; }

        [DataMember(Name = "achievement")]
        public AchievementInfo Achievement { get; set; }

        [DataMember(Name = "featOfStrength")]
        public bool FeatOfStrength { get; set; }

        [DataMember(Name = "criteria")]
        public AchievementCriteria Criteria { get; set; }

        [DataMember(Name = "quantity")]
        public int Quantity { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "itemId")]
        public int ItemId { get; set; }

    }
}
