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
            "http://{0}." + ExplorerUtil.host;

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
            return GetData<RealmList>(string.Format(baseAPIurl + RealmUtil.basePath, region)).Realms;
        }

        private T GetData<T>(string url) where T : class
        {
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(ExplorerUtil.GetJson(WebClient, url))))
            {
                DataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));
                return DataContractJsonSerializer.ReadObject(stream) as T;
            }
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
