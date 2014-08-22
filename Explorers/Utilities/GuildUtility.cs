using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Utilities
{
    public static class GuildUtility
    {
        public const string basePath = "/wow/guild/";
        public const string rewardsPath = "/wow/data/guild/rewards";
        public const string perksPath = "/wow/data/guild/perks";

        public static string buildOptionalQuery(GuildOptions realmOptions)
        {
            string query = "&fields=";
            List<string> tmp = new List<string>();

            if ((realmOptions & GuildOptions.GetMembers) == GuildOptions.GetMembers)
                tmp.Add("members");

            if ((realmOptions & GuildOptions.GetAchievements) == GuildOptions.GetAchievements)
                tmp.Add("achievements");

            if ((realmOptions & GuildOptions.GetNews) == GuildOptions.GetNews)
                tmp.Add("news");

            if (tmp.Count == 0) return string.Empty;

            query += string.Join(",", tmp.ToArray());

            return query;
        }

    }
}
