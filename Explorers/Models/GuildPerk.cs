using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class GuildPerk
    {
        [DataMember(Name="guildLevel")]
        public int GuildLevel { get; set; }

        [DataMember(Name = "spell")]
        public GuildPerkSpell Spell { get; set; }

    }
}
