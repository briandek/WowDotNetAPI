using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class Guild
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "realm")]
        public string Realm { get; set; }

        [DataMember(Name = "side")]
        public int Side { get; set; }

        [DataMember(Name = "level")]
        public int Level { get; set; }

        [DataMember(Name = "achievementPoints")]
        public int AchievementPoints { get; set; }

        [DataMember(Name = "lastModified")]
        public long LastModified { get; set; }

        [DataMember(Name = "members")]
        public IEnumerable<GuildMember> Members { get; set; }

        [DataMember(Name = "achievements")]
        public Achievements Achievements { get; set; }
    }
}
