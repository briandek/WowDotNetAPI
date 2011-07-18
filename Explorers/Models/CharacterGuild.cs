using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace WowDotNetAPI.Models
{
    [DataContract]
    public class CharacterGuild
    {
        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name = "realm")]
        public string Realm { get; set; }

        [DataMember(Name = "level")]
        public int Level { get; set; }

        [DataMember(Name = "achievementPoints")]
        public int AchievementPoints { get; set; }

        [DataMember(Name = "members")]
        public int Members { get; set; }

        [DataMember(Name = "emblem")]
        public CharacterGuildEmblem Emblem { get; set; }
    }
}
