using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.GuildExplorerModels;

namespace WowDotNetAPI.Explorers.Interfaces
{
    public interface IGuildExplorer : IExplorer<Guild>
    {
        string Region { get; set; }
        string Name { get; set; }
        string Realm { get; set; }

        Guild Guild { get; }
        Guild GetGuild(string name, string realm, bool getMembers, bool getAchievements);
        Guild GetGuild(string region, string name, string realm, bool getMembers, bool getAchievements);
    }
}
