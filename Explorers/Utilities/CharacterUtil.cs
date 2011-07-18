using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.Utilities
{
    public static class CharacterUtil
    {
        public const string basePath = "/api/wow/character/";
        public const string racesPath = "/api/wow/data/character/races";
        public const string classesPath = "/api/wow/data/character/classes";

        public static string buildOptionalQuery(
            bool getGuildInfo,
            bool getStatsInfo,
            bool getTalentsInfo,
            bool getItemsInfo,
            bool getReputationInfo,
            bool getTitlesInfo,
            bool getProfessionsInfo,
            bool getAppearanceInfo,
            bool getCompanionsInfo,
            bool getMountsInfo,
            bool getPetsInfo,
            bool getAchievementsInfo,
            bool getProgressionInfo)
        {
            string query = "?fields=";
            List<string> tmp = new List<string>();

            if (getGuildInfo)
                tmp.Add("guild");

            if (getStatsInfo)
                tmp.Add("stats");

            if (getTalentsInfo)
                tmp.Add("talents");

            if (getItemsInfo)
                tmp.Add("items");

            if (getReputationInfo)
                tmp.Add("reputation");

            if (getTitlesInfo)
                tmp.Add("titles");

            if (getProfessionsInfo)
                tmp.Add("professions");

            if (getAppearanceInfo)
                tmp.Add("appearance");

            if (getCompanionsInfo)
                tmp.Add("companions");

            if (getMountsInfo)
                tmp.Add("mounts");

            if (getPetsInfo)
                tmp.Add("pets");

            if (getAchievementsInfo)
                tmp.Add("achievements");

            if (getProgressionInfo)
                tmp.Add("progression");

            query += string.Join(",", tmp);

            return query;
        }
    }
}
