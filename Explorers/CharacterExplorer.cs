using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.Interfaces;
using System.Net;
using System.Web.Script.Serialization;
using WowDotNetAPI.Explorers.Models;
using WowDotNetAPI.Explorers.Utilities;

namespace WowDotNetAPI.Explorers
{
    public class CharacterExplorer : ICharacterExplorer
    {

        private const string baseRealmAPIurl =
            "http://{0}." + ExplorerUtil.host + CharacterUtil.basePath + "{1}/{2}";

        public WebClient WebClient { get; set; }
        public JavaScriptSerializer JavaScriptSerializer { get; set; }

        public CharacterExplorer()
        {
            JavaScriptSerializer = new JavaScriptSerializer();
            WebClient = new WebClient();
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
            return GetData(string.Format(baseRealmAPIurl, region , realm, name)
                + buildOptionalQuery(
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


        private Character GetData(string url)
        {
            return JavaScriptSerializer.Deserialize<Character>(ExplorerUtil.GetJson(WebClient, url));
        }

        private string buildOptionalQuery(
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

            if (getProfessionsInfo)
                tmp.Add("professions");

            query += string.Join(",", tmp);

            return query;
        }

        public void Dispose()
        {
            if (WebClient != null) WebClient.Dispose();
        }
    }
}
