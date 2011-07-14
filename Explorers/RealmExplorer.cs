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
        private const string baseRealmAPIurl =
            "http://{0}." + ExplorerUtil.host + "/" + RealmUtil.basePath;

        public WebClient WebClient { get; set; }
        public JavaScriptSerializer JavaScriptSerializer { get; set; }


        public RealmExplorer() : this("us") { }

        public RealmExplorer(string region)
        {
            JavaScriptSerializer = new JavaScriptSerializer();
            WebClient = new WebClient();
        }

        public IEnumerable<Realm> GetRealms()
        {
            return GetRealms("us");
        }

        public IEnumerable<Realm> GetRealms(string region)
        {
            return GetData(string.Format(baseRealmAPIurl, region)).realms;
        }

        public IEnumerable<Realm> GetRealmsViaQuery(string region, string query)
        {
            try
            {
                return GetData(string.Format(baseRealmAPIurl, region, query)).realms;
            }
            catch
            {
                return null;
            }
        }

        private RealmList GetData(string url)
        {
            return JavaScriptSerializer.Deserialize<RealmList>(ExplorerUtil.GetJson(WebClient, url));

            //var jsonObjects = (Dictionary<string, object>)JavaScriptSerializer.DeserializeObject(ExplorerUtil.GetJson(WebClient, url));
            //return JavaScriptSerializer.ConvertToType<IEnumerable<Realm>>(jsonObjects["realms"]);
        }

        public void Dispose()
        {
            if (WebClient != null) WebClient.Dispose();
        }
    }
}
