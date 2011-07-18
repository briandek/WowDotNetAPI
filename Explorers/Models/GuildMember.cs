using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Models
{
    public class GuildMember
    {
        public GuildCharacter character { get; set; }
        public int rank { get; set; }
    }
}
