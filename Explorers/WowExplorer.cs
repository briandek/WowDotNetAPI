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
            return GetCharacter(Region, realm, name,
                false, false, false, false, false, false, false, false, false, false, false, false, false);
        }

        public Character GetCharacter(Region region, string realm, string name)
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

        public Character GetCharacter(Region region, string realm, string name,
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

        public Guild GetGuild(Region region, string realm, string name)
        {
            return GetGuild(region, realm, name, false, false);
        }

        public Guild GetGuild(string realm, string name, bool getMembers, bool getAchievements)
        {
            return GetGuild(Region, realm, name, getMembers, getAchievements);
        }

        public Guild GetGuild(Region region, string realm, string name, bool getMembers, bool getAchievements)
        {
            return GetData<Guild>(string.Format(baseAPIurl + GuildUtil.basePath + "{1}/{2}", region, realm, name) +
                GuildUtil.buildOptionalQuery(getMembers, getAchievements));
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
