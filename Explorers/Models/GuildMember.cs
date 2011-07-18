using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class GuildMember
    {
        [DataMember(Name="character")]
        public GuildCharacter Character { get; set; }

        [DataMember(Name = "rank")]
        public int Rank { get; set; }
    }
}
