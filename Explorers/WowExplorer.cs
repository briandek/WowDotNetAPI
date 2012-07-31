using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;
using WowDotNetAPI.Models;
using WowDotNetAPI.Utilities;
using System.Runtime.Serialization.Json;
using System.IO;
using WowDotNetAPI.Exceptions;

namespace WowDotNetAPI
{
    public enum Region
    {
        US,
        EU,
        KR,
        TW,
        CN
    }

    public enum Locale
    {
        None,
        en_US,
        es_MX,
        en_GB,
        es_ES,
        fr_FR,
        ru_RU,
        de_DE,
        ko_KR,
        zh_TW,
        zh_CN
    }

    [Flags]
    public enum CharacterOptions
    {
        None = 0,
        GetGuild = 1,
        GetStats = 2,
        GetTalents = 4,
        GetItems = 8,
        GetReputation = 16,
        GetTitles = 32,
        GetProfessions = 64,
        GetAppearance = 128,
        GetCompanions = 256,
        GetMounts = 512,
        GetPets = 1024,
        GetAchievements = 2048,
        GetProgression = 4096,
        GetFeed = 8192,
        GetPvP = 16384,
        GetQuests = 32768,
        GetEverything = GetGuild | GetStats | GetTalents | GetItems | GetReputation | GetTitles
        | GetProfessions | GetAppearance | GetCompanions | GetMounts | GetPets
        | GetAchievements | GetProgression | GetFeed | GetPvP | GetQuests
    }

    [Flags]
    public enum GuildOptions
    {
        None = 0,
        GetMembers = 1,
        GetAchievements = 2,
        GetNews = 4,
        GetEverything = GetMembers | GetAchievements | GetNews
    }

    public class WowExplorer : IExplorer
    {
        public Region Region { get; set; }
        public Locale Locale { get; set; }

        private string publicAuthKey { get; set; }
        private string privateAuthKey { get; set; }

        private string BaseAPIurl { get; set; }

        public ErrorInfo ErrorInfo { get; set; }

        public WowExplorer() : this(Region.US) { }

        public WowExplorer(Region region)
            : this(region, Locale.en_US)
        {
            Region = region;
            SetDefaultLocale();
        }

        public WowExplorer(Region region, Locale locale)
        {
            Region = region;
            BaseAPIurl = ExplorerUtility.GetBaseURL(Region);
            Locale = locale;
        }

        public WowExplorer(Region region, Locale locale, string publicKey, string privateKey)
            : this(region, locale)
        {
            publicAuthKey = publicKey;
            privateAuthKey = privateKey;
        }

        #region Locale
        public void SetDefaultLocale()
        {
            switch (Region)
            {
                case Region.US:
                    Locale = Locale.en_US;
                    break;
                case Region.EU:
                    Locale = Locale.en_GB;
                    break;
                case Region.KR:
                    Locale = Locale.ko_KR;
                    break;
                case Region.TW:
                    Locale = Locale.zh_TW;
                    break;
                case Region.CN:
                    Locale = Locale.zh_CN;
                    break;
                default:
                    break;
            }
        }

        public void SetLocale(Locale locale)
        {
            switch (locale)
            {
                case Locale.en_US:
                case Locale.es_MX:
                    if (Region == Region.US) { Locale = locale; }
                    else { throw new InvalidLocaleException(string.Format("The {0} locale is not associated with the {1} region", locale, Region), Region, Locale); }
                    break;
                case Locale.en_GB:
                case Locale.es_ES:
                case Locale.fr_FR:
                case Locale.ru_RU:
                case Locale.de_DE:
                    if (Region == Region.EU) { Locale = locale; }
                    else { throw new InvalidLocaleException(string.Format("The {0} locale is not associated with the {1} region", locale, Region), Region, Locale); }
                    break;
                case Locale.ko_KR:
                    if (Region == Region.KR) { Locale = locale; }
                    else { throw new InvalidLocaleException(string.Format("The {0} locale is not associated with the {1} region", locale, Region), Region, Locale); }
                    break;
                case Locale.zh_TW:
                    if (Region == Region.TW) { Locale = locale; }
                    else { throw new InvalidLocaleException(string.Format("The {0} locale is not associated with the {1} region", locale, Region), Region, Locale); }
                    break;
                case Locale.zh_CN:
                    if (Region == Region.CN) { Locale = locale; }
                    else { throw new InvalidLocaleException(string.Format("The {0} locale is not associated with the {1} region", locale, Region), Region, Locale); }
                    break;
                default:
                    Locale = Locale.None;
                    break;
            }
        }

        private string GetLocaleQuery()
        {
            return "?locale=" + Locale;
        }

        #endregion

        #region Character

        public Character GetCharacter(string realm, string name)
        {
            return GetCharacter(Region, realm, name, CharacterOptions.None);
        }

        public Character GetCharacter(Region region, string realm, string name)
        {
            return GetCharacter(region, realm, name, CharacterOptions.None);
        }

        public Character GetCharacter(string realm, string name, CharacterOptions characterOptions)
        {
            return GetCharacter(Region, realm, name, characterOptions);
        }

        public Character GetCharacter(Region region, string realm, string name, CharacterOptions characterOptions)
        {
            Character character;

            TryGetData<Character>(BaseAPIurl
                + string.Format(CharacterUtility.basePath + "{0}/{1}", realm, name)
                + GetLocaleQuery()
                + CharacterUtility.buildOptionalQuery(characterOptions), out character);

            return character;
        }

        #endregion

        #region Guild

        public Guild GetGuild(string realm, string name)
        {
            return GetGuild(Region, realm, name, GuildOptions.None);
        }

        public Guild GetGuild(Region region, string realm, string name)
        {
            return GetGuild(region, realm, name, GuildOptions.None);
        }

        public Guild GetGuild(string realm, string name, GuildOptions realmOptions)
        {
            return GetGuild(Region, realm, name, realmOptions);
        }

        public Guild GetGuild(Region region, string realm, string name, GuildOptions realmOptions)
        {
            Guild guild;

            TryGetData<Guild>(BaseAPIurl
                + string.Format(GuildUtility.basePath + "{0}/{1}", realm, name)
                + GetLocaleQuery()
                + GuildUtility.buildOptionalQuery(realmOptions), out guild);

            return guild;
        }

        #endregion

        #region Realms
        public IEnumerable<Realm> GetRealms()
        {
            return GetRealms(Region);
        }

        public IEnumerable<Realm> GetRealms(Region region)
        {
            RealmsData realmsData;

            TryGetData<RealmsData>(BaseAPIurl
                + RealmUtility.basePath
                + GetLocaleQuery(), out realmsData);

            return (realmsData != null) ? realmsData.Realms : null;
        }

        #endregion

        #region Auctions

        public Auctions GetAuctions(string realm)
        {
            string url = "";

            AuctionFiles auctionFiles;
            TryGetData<AuctionFiles>(string.Format(BaseAPIurl
                + string.Format(AuctionUtility.basePath, realm.ToLower().Replace(' ', '-'))
                + GetLocaleQuery()), out auctionFiles);

            if (auctionFiles != null)
            {
                foreach (AuctionFile auctionFile in auctionFiles.Files)
                {
                    url = auctionFile.URL;
                }

                Auctions auctions;

                TryGetData<Auctions>(url, out auctions);

                return auctions;
            }

            return null;
        }

        #endregion

        #region Items

        public Item GetItem(string id)
        {
            Item item;

            TryGetData<Item>(BaseAPIurl + string.Format(ItemUtility.basePath, id) + GetLocaleQuery(), out item);

            return item;
        }

        public IEnumerable<ItemClassInfo> GetItemClasses()
        {
            ItemClassData itemclassdata;

            TryGetData<ItemClassData>(BaseAPIurl + DataUtility.itemClassesPath + GetLocaleQuery(), out itemclassdata);

            return (itemclassdata != null) ? itemclassdata.Classes : null;
        }

        #endregion

        #region CharacterRaceInfo
        public IEnumerable<CharacterRaceInfo> GetCharacterRaces()
        {
            return GetCharacterRaces(Region);
        }

        public IEnumerable<CharacterRaceInfo> GetCharacterRaces(Region region)
        {
            CharacterRacesData charRacesData;
            TryGetData<CharacterRacesData>(BaseAPIurl + DataUtility.characterRacesPath + GetLocaleQuery(), out charRacesData);
            return (charRacesData != null) ? charRacesData.Races : null;
        }
        #endregion

        #region CharacterClassInfo
        public IEnumerable<CharacterClassInfo> GetCharacterClasses()
        {
            return GetCharacterClasses(Region);
        }

        public IEnumerable<CharacterClassInfo> GetCharacterClasses(Region region)
        {
            CharacterClassesData characterClasses;
            TryGetData<CharacterClassesData>(BaseAPIurl + DataUtility.characterClassesPath + GetLocaleQuery(), out characterClasses);
            return (characterClasses != null) ? characterClasses.Classes : null;
        }
        #endregion

        #region GuildRewardInfo
        public IEnumerable<GuildRewardInfo> GetGuildRewards()
        {
            return GetGuildRewards(Region);
        }

        public IEnumerable<GuildRewardInfo> GetGuildRewards(Region region)
        {
            GuildRewardsData guildRewardsData;
            TryGetData<GuildRewardsData>(BaseAPIurl + DataUtility.guildRewardsPath + GetLocaleQuery(), out guildRewardsData);
            return (guildRewardsData != null) ? guildRewardsData.Rewards : null;
        }
        #endregion

        #region GuildPerkInfo
        public IEnumerable<GuildPerkInfo> GetGuildPerks()
        {
            return GetGuildPerks(Region);
        }

        public IEnumerable<GuildPerkInfo> GetGuildPerks(Region region)
        {
            GuildPerksData guildPerksData;
            TryGetData<GuildPerksData>(BaseAPIurl + DataUtility.guildPerksPath + GetLocaleQuery(), out guildPerksData);
            return (guildPerksData != null) ? guildPerksData.Perks : null;
        }
        #endregion

        #region Achievements
        public AchievementInfo GetAchievement(int id)
        {
            AchievementInfo achievement;

            TryGetData<AchievementInfo>(BaseAPIurl + string.Format(AchievementUtility.basePath, id) + GetLocaleQuery(), out achievement);

            return achievement;
        }

        public IEnumerable<AchievementList> GetAchievements()
        {
            AchievementData achievementData;

            TryGetData<AchievementData>(BaseAPIurl + AchievementUtility.listPath + GetLocaleQuery(), out achievementData);

            return (achievementData != null) ? achievementData.Lists : null;
        }

        public IEnumerable<AchievementList> GetGuildAchievements()
        {
            AchievementData achievementData;

            TryGetData<AchievementData>(BaseAPIurl + AchievementUtility.guildPath + GetLocaleQuery(), out achievementData);

            return (achievementData != null) ? achievementData.Lists : null;
        }

        #endregion

        #region Battlegroups
        public IEnumerable<BattlegroupInfo> GetBattlegroups()
        {
            BattlegroupData battlegroupData;

            TryGetData<BattlegroupData>(BaseAPIurl + DataUtility.battlegroundPath + GetLocaleQuery(), out battlegroupData);

            return (battlegroupData != null) ? battlegroupData.Battlegroups : null;
        }
        #endregion

        private T GetData<T>(string url) where T : class
        {
            if (!string.IsNullOrEmpty(privateAuthKey) && !string.IsNullOrEmpty(publicAuthKey))
            {
                return JsonUtility.FromJSON<T>(url, publicAuthKey, privateAuthKey);
            }

            return JsonUtility.FromJSON<T>(url);
        }

        private void TryGetData<T>(string url, out T requestedObject) where T : class
        {
            try
            {
                if (!string.IsNullOrEmpty(privateAuthKey) && !string.IsNullOrEmpty(publicAuthKey))
                {
                    requestedObject = JsonUtility.FromJSON<T>(url, publicAuthKey, privateAuthKey);
                }

                requestedObject = JsonUtility.FromJSON<T>(url);
            }
            catch (WowException wowEx)
            {
                ErrorInfo = new ErrorInfo
                {
                    ErrorDetail = wowEx.ErrorDetail,
                    OriginalException = wowEx.OriginalException,
                    RequestUrl = wowEx.Url
                };
                requestedObject = null;
            }
            catch (WebException webEx)
            {
                ErrorInfo = new ErrorInfo
                {
                    ErrorDetail = null,
                    OriginalException = webEx,
                    RequestUrl = string.Empty
                };
                requestedObject = null;
            }
            catch (Exception ex)
            {
                ErrorInfo = new ErrorInfo
                {
                    ErrorDetail = null,
                    OriginalException = ex,
                    RequestUrl = string.Empty
                };
                requestedObject = null;
            }
        }
    }
}
