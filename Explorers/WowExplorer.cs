using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Interfaces;
using System.Net;
using System.Web.Script.Serialization;
using WowDotNetAPI.Models;
using WowDotNetAPI.Utilities;
using System.Runtime.Serialization.Json;
using System.IO;

namespace WowDotNetAPI
{
    public class WowExplorer : IExplorer
    {
        private const string baseAPIurl =
            "https://{0}." + ExplorerUtil.host;

        public WebClient WebClient { get; set; }
        public DataContractJsonSerializer DataContractJsonSerializer { get; set; }

        public string Region { get; set; }

        public WowExplorer() : this("us") { }

        public WowExplorer(string region)
        {
            WebClient = new WebClient();
            WebClient.Encoding = Encoding.UTF8;
            Region = region;
        }

        public Character GetCharacter(string realm, string name)
        {
            return GetCharacter(Region, realm, name,
                false, false, false, false, false, false, false, false, false, false, false, false, false);
        }

        public Character GetCharacter(string region, string realm, string name)
        {
            return GetCharacter(region, realm, name,
                false, false, false, false, false, false, false, false, false, false, false, false, false);
        }

        public Character GetCharacter(string realm, string name,
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
            return GetCharacter(Region, realm, name,
                getGuildInfo,
                getStatsInfo,
                getTalentsInfo,
                getItemsInfo,
                getReputationInfo,
                getTitlesInfo,
                getProfessionsInfo,
                getAppearanceInfo,
                getCompanionsInfo,
                getMountsInfo,
                getPetsInfo,
                getAchievementsInfo,
                getProgressionInfo);
        }

        public Character GetCharacter(string region, string realm, string name,
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
            return GetData<Character>(string.Format(baseAPIurl + CharacterUtil.basePath + "{1}/{2}", region, realm, name)
                + CharacterUtil.buildOptionalQuery(
                getGuildInfo,
                getStatsInfo,
                getTalentsInfo,
                getItemsInfo,
                getReputationInfo,
                getTitlesInfo,
                getProfessionsInfo,
                getAppearanceInfo,
                getCompanionsInfo,
                getMountsInfo,
                getPetsInfo,
                getAchievementsInfo,
                getProgressionInfo));

        }

        public Guild GetGuild(string realm, string name)
        {
            return GetGuild(Region, realm, name, false, false);
        }

        public Guild GetGuild(string region, string realm, string name)
        {
            return GetGuild(region, realm, name, false, false);
        }

        public Guild GetGuild(string realm, string name, bool getMembers, bool getAchievements)
        {
            return GetGuild(Region, realm, name, getMembers, getAchievements);
        }

        public Guild GetGuild(string region, string realm, string name, bool getMembers, bool getAchievements)
        {
            return GetData<Guild>(string.Format(baseAPIurl + GuildUtil.basePath + "{1}/{2}", region, realm, name) +
                GuildUtil.buildOptionalQuery(getMembers, getAchievements));
        }

        public IEnumerable<Realm> GetRealms()
        {
            return GetRealms(Region);
        }

        public IEnumerable<Realm> GetRealms(string region)
        {
            return GetData<RealmsData>(string.Format(baseAPIurl + RealmUtil.basePath, region)).Realms;
        }

        public IEnumerable<CharacterRace> GetCharacterRaces()
        {
            return GetCharacterRaces(Region);
        }

        public IEnumerable<CharacterRace> GetCharacterRaces(string region)
        {
            return GetData<CharacterRacesData>(string.Format(baseAPIurl + DataUtil.characterRacesPath, region)).Races;
        }

        public IEnumerable<CharacterClass> GetCharacterClasses()
        {
            return GetCharacterClasses(Region);
        }

        public IEnumerable<CharacterClass> GetCharacterClasses(string region)
        {
            return GetData<CharacterClassesData>(string.Format(baseAPIurl + DataUtil.characterClassesPath, region)).Classes;
        }

        public IEnumerable<GuildReward> GetGuildRewards()
        {
            return GetGuildRewards(Region);
        }

        public IEnumerable<GuildReward> GetGuildRewards(string region)
        {
            return GetData<GuildRewardsData>(string.Format(baseAPIurl + DataUtil.guildRewardsPath, region)).Rewards;
        }

        public IEnumerable<GuildPerk> GetGuildPerks()
        {
            return GetGuildPerks(Region);
        }

        public IEnumerable<GuildPerk> GetGuildPerks(string region)
        {
            return GetData<GuildPerksData>(string.Format(baseAPIurl + DataUtil.guildPerksPath, region)).Perks;
        }

        private T GetData<T>(string url) where T : class
        {
            return ExplorerUtil.FromJSON<T>(WebClient, url);
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
