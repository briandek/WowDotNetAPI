using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WowDotNetAPI.Models
{
    public class Guild
    {
        public string name { get; set; }
        public string realm { get; set; }
        public int side { get; set; }
        public int level { get; set; }
        public int achievementPoints { get; set; }
        public long lastModified { get; set; }

        public IEnumerable<GuildMember> members { get; set; }
        public Achievements achievements { get; set; }
    }
}
