using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WowDotNetAPI.Utilities
{
    public static class DataUtility
    {
        public const string characterRacesPath = "/api/wow/data/character/races";
        public const string characterClassesPath = "/api/wow/data/character/classes";
        public const string guildRewardsPath = "/api/wow/data/guild/rewards";
        public const string guildPerksPath = "/api/wow/data/guild/perks";
        public const string itemsPath = "/api/wow/data/item/";
        public const string itemClassesPath = "/api/wow/data/item/classes";
        public const string battlegroundPath = "/api/wow/data/battlegroups/";

        public static DateTime ConvertEpoch(long epoch)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(epoch);
        }
    }
}
