using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class GuildPerksData
    {
        [DataMember(Name="perks")]
        public IEnumerable<GuildPerkInfo> Perks { get; set; }
    }
}
