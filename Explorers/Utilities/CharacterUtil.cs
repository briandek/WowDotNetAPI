using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Utilities
{
    public static class CharacterUtil
    {
        public const string basePath = "/api/wow/character/";
        public const string racesPath = "/api/wow/data/character/races";
        public const string classesPath = "/api/wow/data/character/classes";

        public static string buildOptionalQuery(CharacterOptions characterOptions)
        {
            string query = "&fields=";
            List<string> tmp = new List<string>();

            if ((characterOptions & CharacterOptions.GetGuild) == CharacterOptions.GetGuild)
                tmp.Add("guild");

            if ((characterOptions & CharacterOptions.GetStats) == CharacterOptions.GetStats)
                tmp.Add("stats");

            if ((characterOptions & CharacterOptions.GetTalents) == CharacterOptions.GetTalents)
                tmp.Add("talents");

            if ((characterOptions & CharacterOptions.GetItems) == CharacterOptions.GetItems)
                tmp.Add("items");

            if ((characterOptions & CharacterOptions.GetReputation) == CharacterOptions.GetReputation)
                tmp.Add("reputation");

            if ((characterOptions & CharacterOptions.GetTitles) == CharacterOptions.GetTitles)
                tmp.Add("titles");

            if ((characterOptions & CharacterOptions.GetProfessions) == CharacterOptions.GetProfessions)
                tmp.Add("professions");

            if ((characterOptions & CharacterOptions.GetAppearance) == CharacterOptions.GetAppearance)
                tmp.Add("appearance");

            if ((characterOptions & CharacterOptions.GetCompanions) == CharacterOptions.GetCompanions)
                tmp.Add("companions");

            if ((characterOptions & CharacterOptions.GetMounts) == CharacterOptions.GetMounts)
                tmp.Add("mounts");

            if ((characterOptions & CharacterOptions.GetPets) == CharacterOptions.GetPets)
                tmp.Add("pets");

            if ((characterOptions & CharacterOptions.GetAchievements) == CharacterOptions.GetAchievements)
                tmp.Add("achievements");

            if ((characterOptions & CharacterOptions.GetProgression) == CharacterOptions.GetProgression)
                tmp.Add("progression");

            if (tmp.Count == 0) return string.Empty;

            query += string.Join(",", tmp);

            return query;
        }
    }
}
