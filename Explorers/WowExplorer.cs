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

namespace WowDotNetAPI
{
    public enum Region
    {
        US,
        EU,
        KR,
        TW
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
        GetEverything = GetGuild | GetStats | GetTalents | GetItems | GetReputation | GetTitles
        | GetProfessions | GetAppearance | GetCompanions | GetMounts | GetPets
        | GetAchievements | GetProgression
    }

    [Flags]
    public enum GuildOptions
    {
        None = 0,
        GetMembers = 1,
        GetAchievements = 2,
        GetEverything = GetMembers | GetAchievements
    }

    public class WowExplorer : IExplorer
    {
        private const string baseAPIurl = "https://{0}." + ExplorerUtil.host;

        public WebClient WebClient { get; set; }

        public Region Region { get; set; }

        public WowExplorer() : this(Region.US) { }

        public WowExplorer(Region region)
        {
            WebClient = new WebClient();
            WebClient.Encoding = Encoding.UTF8;
            Region = region;
        }

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
            return GetData<Character>(string.Format(baseAPIurl + CharacterUtil.basePath + "{1}/{2}", region, realm, name)
                + CharacterUtil.buildOptionalQuery(characterOptions));

        }

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
            return GetData<Guild>(string.Format(baseAPIurl + GuildUtil.basePath + "{1}/{2}", region, realm, name) +
                GuildUtil.buildOptionalQuery(realmOptions));
        }

        public IEnumerable<Realm> GetRealms()
        {
            return GetRealms(Region);
        }

        public IEnumerable<Realm> GetRealms(Region region)
        {
            return GetData<RealmsData>(string.Format(baseAPIurl + RealmUtil.basePath, region)).Realms;
        }

        public IEnumerable<CharacterRaceInfo> GetCharacterRaces()
        {
            return GetCharacterRaces(Region);
        }

        public IEnumerable<CharacterRaceInfo> GetCharacterRaces(Region region)
        {
            return GetData<CharacterRacesData>(string.Format(baseAPIurl + DataUtility.characterRacesPath, region)).Races;
        }

        public IEnumerable<CharacterClassInfo> GetCharacterClasses()
        {
            return GetCharacterClasses(Region);
        }

        public IEnumerable<CharacterClassInfo> GetCharacterClasses(Region region)
        {
            return GetData<CharacterClassesData>(string.Format(baseAPIurl + DataUtility.characterClassesPath, region)).Classes;
        }

        public IEnumerable<GuildRewardInfo> GetGuildRewards()
        {
            return GetGuildRewards(Region);
        }

        public IEnumerable<GuildRewardInfo> GetGuildRewards(Region region)
        {
            return GetData<GuildRewardsData>(string.Format(baseAPIurl + DataUtility.guildRewardsPath, region)).Rewards;
        }

        public IEnumerable<GuildPerkInfo> GetGuildPerks()
        {
            return GetGuildPerks(Region);
        }

        public IEnumerable<GuildPerkInfo> GetGuildPerks(Region region)
        {
            return GetData<GuildPerksData>(string.Format(baseAPIurl + DataUtility.guildPerksPath, region)).Perks;
        }

        private T GetData<T>(string url) where T : class
        {
            return JsonUtility.FromJSON<T>(WebClient, url);
        }

        public void Dispose()
        {
            if (WebClient != null)
            {
                WebClient.Dispose();
            }
        }


    }
}
