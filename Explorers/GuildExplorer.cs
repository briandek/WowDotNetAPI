using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.Interfaces;
using WowDotNetAPI.Explorers.Models;
using System.Net;
using System.Web.Script.Serialization;
using WowDotNetAPI.Explorers.Utilities;


namespace WowDotNetAPI.Explorers
{
    public class GuildExplorer : IGuildExplorer
    {
        private const string baseRealmAPIurl =
            "http://{0}." + ExplorerUtil.host + GuildUtil.basePath + "/{1}/{2}?fields=";

        public Guild Guild { get; private set; }
        public WebClient WebClient { get; set; }
        public JavaScriptSerializer JavaScriptSerializer { get; set; }

        public string Region { get; set; }
        public string Realm { get; set; }
        public string Name { get; set; }

        public bool GetMembers { get; set; }
        public bool GetAchievements { get; set; }

        public GuildExplorer() : this("us") { }

        public GuildExplorer(string region)
        {
            JavaScriptSerializer = new JavaScriptSerializer();
            WebClient = new WebClient();
            Region = region;
        }

        public void Refresh()
        {
            Guild = GetData(string.Format(baseRealmAPIurl, Region, Realm, Name) +
                (GetMembers ? "members," : string.Empty) +
                (GetAchievements ? "achievements" : string.Empty)
            );
        }

        public Guild GetGuild(string realm, string name, bool getMembers, bool getAchievements)
        {
            return GetGuild("us", realm, name, getMembers, getAchievements);
        }

        public Guild GetGuild(string region, string realm, string name, bool getMembers, bool getAchievements)
        {
            Region = region;
            Name = name;
            Realm = realm;
            GetMembers = getMembers;
            GetAchievements = getAchievements;

            Refresh();

            return Guild;
        }

        private Guild GetData(string url)
        {
            return JavaScriptSerializer.Deserialize<Guild>(ExplorerUtil.GetJson(WebClient, url));
        }

        private string GetJson(string url)
        {
            return WebClient.DownloadString(url);
        }

        public void Dispose()
        {
            if (WebClient != null) WebClient.Dispose();
        }
    }
}
