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
            "http://{0}." + ExplorerUtil.host + GuildUtil.basePath + "/{1}/{2}?fields=achievements,members";

        public Guild Guild { get; private set; }

        public WebClient WebClient { get; set; }
        public JavaScriptSerializer JavaScriptSerializer { get; set; }

        private string region = string.Empty;
        public string Region { get { return region; } set { region = value; Refresh(); } }

        public string Realm { get; set; }
        public string Name { get; set; }

        public GuildExplorer(string realm, string name) : this("us", realm, name){}

        public GuildExplorer(string region, string realm, string name)
        {
            JavaScriptSerializer = new JavaScriptSerializer();
            WebClient = new WebClient();

            Name = name;
            Realm = realm;
            this.Region = region;
        }

        public void Refresh()
        {
            Guild = GetData(string.Format(baseRealmAPIurl, Region, Realm, Name));
        }

        private Guild GetData(string url)
        {
            var guildJsonObject= (Dictionary<string, object>)JavaScriptSerializer.DeserializeObject(GetJson(url));
            return JavaScriptSerializer.ConvertToType<Guild>(guildJsonObject);
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
