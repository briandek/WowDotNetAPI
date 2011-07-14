using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.Models;

namespace WowDotNetAPI.Explorers.Interfaces
{
    public interface IGuildExplorer : IExplorer<Guild>
    {
        Guild GetGuild(string realm, string name, bool getMembers, bool getAchievements);
        Guild GetGuild(string region, string realm, string name, bool getMembers, bool getAchievements);
    }
}
