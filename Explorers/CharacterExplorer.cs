using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.Interfaces;
using System.Net;
using System.Web.Script.Serialization;
using WowDotNetAPI.Explorers.CharacterExplorerModels;
using WowDotNetAPI.Explorers.Utilities;

namespace WowDotNetAPI.Explorers
{
    public class CharacterExplorer : ICharacterExplorer
    {

        private const string baseRealmAPIurl =
            "http://{0}." + ExplorerUtil.host + CharacterUtil.basePath + "{1}/{2}";

        public WebClient WebClient { get; set; }
        public JavaScriptSerializer JavaScriptSerializer { get; set; }

        public string Region { get; set; }
        public string Realm { get; set; }
        public string Name { get; set; }

        public Character Character { get; private set; }

        public bool GetGuildInfo { get; set; }
        public bool GetStatsInfo { get; set; }
        public bool GetTalentsInfo { get; set; }
        public bool GetItemsInfo { get; set; }
        public bool GetReputationInfo { get; set; }
        public bool GetTitlesInfo { get; set; }
        public bool GetProfessionsInfo { get; set; }
        public bool GetAppearanceInfo { get; set; }
        public bool GetCompanionsInfo { get; set; }
        public bool GetMountsInfo { get; set; }
        public bool GetPetsInfo { get; set; }
        public bool GetAchievementsInfo { get; set; }
        public bool GetProgressionInfo { get; set; }

        public CharacterExplorer() : this("us") { }
        public CharacterExplorer(string region)
        {
            JavaScriptSerializer = new JavaScriptSerializer();
            WebClient = new WebClient();
            Region = region;
        }

        //There has to be a cleaner way to define query ._.
        //TODO: research cleaner query constructor
        public Character GetCharacter(string realm, string name)
        {
            return GetCharacter("us", realm, name,
                false, false, false, false, false, false, false, false, false, false, false, false, false);
        }

        public Character GetCharacter(string region, string realm, string name)
        {
            return GetCharacter("us", realm, name,
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
            return GetCharacter("us", realm, name,
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
            Region = region;
            Realm = realm;
            Name = name;

            GetGuildInfo = getGuildInfo;
            GetStatsInfo = getStatsInfo;
            GetTalentsInfo = getTalentsInfo;
            GetItemsInfo = getItemsInfo;
            GetReputationInfo = getReputationInfo;
            GetTitlesInfo = getTitlesInfo;
            GetProfessionsInfo = getProfessionsInfo;
            GetAppearanceInfo = getAppearanceInfo;
            GetCompanionsInfo = getCompanionsInfo;
            GetMountsInfo = getMountsInfo;
            GetPetsInfo = getPetsInfo;
            GetAchievementsInfo = getAchievementsInfo;
            GetProfessionsInfo = getProfessionsInfo;

            Refresh();
            return Character;
        }


        private Character GetData(string url)
        {
            return JavaScriptSerializer.Deserialize<Character>(ExplorerUtil.GetJson(WebClient, url));
        }

        public void Refresh()
        {
            Character = GetData(string.Format(baseRealmAPIurl, Region, Realm, Name) + buildOptionalQuery());

        }

        private string buildOptionalQuery()
        {
            string query = "?fields=";
            List<string> tmp = new List<string>();

            if (GetGuildInfo)
                tmp.Add("guild");

            if (GetStatsInfo)
                tmp.Add("stats");

            if (GetTalentsInfo)
                tmp.Add("talents");

            if (GetItemsInfo)
                tmp.Add("items");

            if (GetReputationInfo)
                tmp.Add("reputation");

            if (GetTitlesInfo)
                tmp.Add("titles");

            if (GetProfessionsInfo)
                tmp.Add("professions");

            if (GetAppearanceInfo)
                tmp.Add("appearance");

            if (GetCompanionsInfo)
                tmp.Add("companions");

            if (GetMountsInfo)
                tmp.Add("mounts");

            if (GetPetsInfo)
                tmp.Add("pets");

            if (GetAchievementsInfo)
                tmp.Add("achievements");

            if (GetProfessionsInfo)
                tmp.Add("professions");

            query += string.Join(",", tmp);

            return query;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
