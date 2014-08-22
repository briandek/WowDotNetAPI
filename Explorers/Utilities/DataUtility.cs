using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WowDotNetAPI.Utilities
{
    public static class DataUtility
    {
        public const string characterRacesPath = "/wow/data/character/races";
        public const string characterClassesPath = "/wow/data/character/classes";
        public const string guildRewardsPath = "/wow/data/guild/rewards";
        public const string guildPerksPath = "/wow/data/guild/perks";
        public const string itemsPath = "/wow/data/item/";
        public const string itemClassesPath = "/wow/data/item/classes";
        public const string battlegroundPath = "/wow/data/battlegroups/";
        public const string challengesPath = "/wow/challenge/";

        public static Region GetRegion(string region)
        {
            switch (region)
            {
                case "CN":
                    return Region.CN;
                case "EU":
                    return Region.EU;
                case "KR":
                    return Region.KR;
                case "TW":
                    return Region.TW;
                case "US":
                default:
                    return Region.US;
            }
        }

        public static Locale GetLocale(string locale)
        {
            switch (locale)
            {
                case "de_DE":
                    return Locale.de_DE;
                case "en_GB":
                    return Locale.en_GB;
                case "es_ES":
                    return Locale.es_ES;
                case "es_MX":
                    return Locale.es_MX;
                case "fr_FR":
                    return Locale.fr_FR;
                case "ko_KR":
                    return Locale.ko_KR;
                case "ru_RU":
                    return Locale.ru_RU;
                case "zh_CN":
                    return Locale.zh_CN;
                case "zh_TW":
                    return Locale.zh_TW;
                case "en_US":
                default:
                    return Locale.en_US;
            }
        }

        public static string GetLocaleQuery(Locale locale)
        {
            return "?locale=" + locale;
        }

        public static DateTime ConvertEpoch(long epoch)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(epoch);
        }
    }
}
