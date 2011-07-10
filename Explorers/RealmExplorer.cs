using System;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using WowDotNetAPI.Explorers.Models;
using System.IO;
using WowDotNetAPI.Explorers.Interfaces;
using WowDotNetAPI.Explorers.Extensions;
using WowDotNetAPI.Explorers.Utilities;

namespace WowDotNetAPI.Explorers
{

    public class RealmExplorer : IRealmExplorer
    {
        private const string baseRealmAPIurl = "http://{0}.battle.net/api/wow/realm/status{1}";

        public IEnumerable<Realm> Realms { get; private set; }
        public WebClient WebClient { get; set; }
        public JavaScriptSerializer JavaScriptSerializer { get; set; }

        public string Region { get; set; }

        public RealmExplorer() : this("us") { }
            
        public RealmExplorer(string region)
        {
            this.Region = region;
            JavaScriptSerializer = new JavaScriptSerializer();
            WebClient = new WebClient();

            Realms = GetData(string.Format(baseRealmAPIurl, Region, string.Empty));
        }

        public void Refresh()
        {
            Realms = GetData(string.Format(baseRealmAPIurl, Region, string.Empty));
        }

        public Realm GetSingleRealm(string name)
        {
            return Realms.Where(realm => realm.name.Equals(name, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
        }

        public IEnumerable<Realm> GetAllRealms()
        {
            return Realms;
        }

        public IEnumerable<Realm> GetMultipleRealms(params string[] names)
        {
            string query = "?realm=" + String.Join("&realm=", names);
            return GetMultipleRealmsViaQuery(query);
        }

        public IEnumerable<Realm> GetMultipleRealmsViaQuery(string query)
        {
            if (string.IsNullOrEmpty(query)) return null;

            try
            {
                return GetData(string.Format(baseRealmAPIurl, Region, query));
            }
            catch
            {
                return null;
            }
        }

        private IEnumerable<Realm> GetData(string url)
        {
            var jsonObjects = (Dictionary<string, object>)JavaScriptSerializer.DeserializeObject(GetJson(url));
            return JavaScriptSerializer.ConvertToType<IEnumerable<Realm>>(jsonObjects["realms"]);
        }

        private string GetJson(string url)
        {
            return WebClient.DownloadString(ExplorerUtil.SanitizeUrl(url));
        }


        public void Dispose()
        {
            if (WebClient != null) WebClient.Dispose();
        }
    }
}
