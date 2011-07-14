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
            "http://{0}." + ExplorerUtil.host + GuildUtil.basePath + "{1}/{2}?fields=";

        public WebClient WebClient { get; set; }
        public JavaScriptSerializer JavaScriptSerializer { get; set; }

        public GuildExplorer() : this("us") { }

        public GuildExplorer(string region)
        {
            JavaScriptSerializer = new JavaScriptSerializer();
            WebClient = new WebClient();
        }

        public Guild GetGuild(string realm, string name, bool getMembers, bool getAchievements)
        {
            return GetGuild("us", realm, name, getMembers, getAchievements);
        }

        public Guild GetGuild(string region, string realm, string name, bool getMembers, bool getAchievements)
        {
            return GetData(string.Format(baseRealmAPIurl, region, realm, name) +
                (getMembers ? "members," : string.Empty) +
                (getAchievements ? "achievements" : string.Empty)
            );
        }

        private Guild GetData(string url)
        {
            try
            {
                return JavaScriptSerializer.Deserialize<Guild>(ExplorerUtil.GetJson(WebClient, url));
            }
            catch
            {
                return null;
            }
        }

        public void Dispose()
        {
            if (WebClient != null) WebClient.Dispose();
        }
    }
}
