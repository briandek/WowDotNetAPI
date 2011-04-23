using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RealmAPI
{
    public class RealmExplorer
    {
        private const string baseRealmAPIurl = "http://{0}.battle.net/api/wow/realm/status{1}";

        public string region { get; set; }

        public RealmExplorer() : this("us") { }

        public RealmExplorer(string region)
        {
            this.region = region;
        }

        public List<Realm> GetAllRealms()
        {
            return GetRealmData(string.Format(baseRealmAPIurl, region, string.Empty));
        }

        public List<Realm> GetAllRealmsByType(string type)
        {
            var realmList = GetRealmData(string.Format(baseRealmAPIurl, region, string.Empty));
            return realmList
                .Where(r => r.type.Equals(type, StringComparison.InvariantCultureIgnoreCase)).ToList<Realm>();
        }

        public List<Realm> GetAllRealmsByPopulation(string population)
        {
            var realmList = GetRealmData(string.Format(baseRealmAPIurl, region, string.Empty));
            return realmList
                .Where(r => r.population.Equals(population, StringComparison.InvariantCultureIgnoreCase)).ToList<Realm>();
        }

        public List<Realm> GetAllRealmsByStatus(bool status)
        {
            var realmList = GetRealmData(string.Format(baseRealmAPIurl, region, string.Empty));
            return realmList
                .Where(r => r.status == status).ToList<Realm>();
        }

        public List<Realm> GetAllRealmsByQueue(bool queue)
        {
            var realmList = GetRealmData(string.Format(baseRealmAPIurl, region, string.Empty));
            return realmList
                .Where(r => r.queue == queue).ToList<Realm>();
        }

        private List<Realm> GetRealmData(string url)
        {
            using (var wc = new WebClient())
            {
                var jsonString = wc.DownloadString(url);
                var jsonObject = JObject.Parse(jsonString);

                return JsonConvert.DeserializeObject<List<Realm>>(jsonObject["realms"].ToString());
            }
        }

        public Realm GetRealm(string name)
        {
            var realmList = GetRealms(name);
            
            if (realmList != null) return realmList.FirstOrDefault();

            return null;
        }

        public List<Realm> GetRealms(params string[] realmNames)
        {
            if (realmNames == null && realmNames.Length > 0) return null;

            var query = "?realm=" + realmNames[0];
            for (int i = 1; i < realmNames.Length; i++)
            {
                query += "&realm=" + realmNames[i];
            }

            try
            {
                return GetRealmData(string.Format(baseRealmAPIurl, region, query));
            }
            catch
            {
                return null;
            }
        }

        public List<Realm> GetRealmsViaQuery(string query)
        {
            if (string.IsNullOrEmpty(query)) return null;

            try
            {
                return GetRealmData(string.Format(baseRealmAPIurl, region, query));
            }
            catch
            {
                return null;
            }
        }
    }
}
