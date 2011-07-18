using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Utilities
{
    public static class GuildUtil
    {
        public const string basePath = "/api/wow/guild/";
        public const string rewardsPath = "/api/wow/data/guild/rewards";
        public const string perksPath = "/api/wow/data/guild/perks";

        public static string buildOptionalQuery(
            bool getMembers,
            bool getAchievements)
        {
            string query = "?fields=";
            List<string> tmp = new List<string>();

            if (getMembers)
                tmp.Add("members");

            if (getAchievements)
                tmp.Add("achievements");

            query += string.Join(",", tmp);

            return query;
        }

    }
}
