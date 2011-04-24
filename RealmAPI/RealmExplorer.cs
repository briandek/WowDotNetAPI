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


        public Realm GetRealm(string name)
        {
            var realmList = GetRealms(name);

            return realmList == null ? null : realmList.FirstOrDefault();
        }
       
        public List<Realm> GetAllRealms()
        {
            return GetRealmData(string.Format(baseRealmAPIurl, region, string.Empty));
        }

        public List<Realm> GetRealmsByType(string type)
        {
            var realmList = GetRealmData(string.Format(baseRealmAPIurl, region, string.Empty));

            return realmList
                .Where(r => r.type.Equals(type, StringComparison.InvariantCultureIgnoreCase)).ToList<Realm>();
        }

        public List<Realm> GetRealmsByPopulation(string population)
        {
            var realmList = GetRealmData(string.Format(baseRealmAPIurl, region, string.Empty));
            return realmList
                .Where(r => r.population.Equals(population, StringComparison.InvariantCultureIgnoreCase)).ToList<Realm>();
        }

        public List<Realm> GetRealmsByStatus(bool status)
        {
            var realmList = GetRealmData(string.Format(baseRealmAPIurl, region, string.Empty));
            return realmList
                .Where(r => r.status == status).ToList<Realm>();
        }

        public List<Realm> GetRealmsByQueue(bool queue)
        {
            var realmList = GetRealmData(string.Format(baseRealmAPIurl, region, string.Empty));
            return realmList
                .Where(r => r.queue == queue).ToList<Realm>();
        }

        public List<Realm> GetRealms(params string[] realmNames)
        {
            if (realmNames == null && realmNames.Length > 0) return null;

            var query = "?realm=" + realmNames[0];
            for (int i = 1; i < realmNames.Length; i++)
            {
                query += "&realm=" + realmNames[i];
            }

            return GetRealmsViaQuery(query);
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

        public string GetRealmsByTypeAsJson(string type)
        {
            return ConvertRealmListToJson(GetRealmsByType(type));
        }

        public string GetRealmsByPopulationAsJson(string population)
        {
            return ConvertRealmListToJson(GetRealmsByPopulation(population));
        }

        public string GetRealmsByStatusAsJson(bool status)
        {
            return ConvertRealmListToJson(GetRealmsByStatus(status));
        }

        public string GetRealmsByQueueAsJson(bool queue)
        {
            return ConvertRealmListToJson(GetRealmsByQueue(queue));
        }

        public string GetAllRealmsAsJson()
        {
            return GetJson(string.Format(baseRealmAPIurl, region, string.Empty));
        }

        public string GetRealmAsJson(string name)
        {
            return ConvertRealmListToJson(GetRealms(name));
        }

        public string GetRealmsAsJson(params string[] realmNames)
        {
            return ConvertRealmListToJson(GetRealms(realmNames));
        }
        
        public string GetRealmsViaQueryAsJson(string query)
        {
            return ConvertRealmListToJson(GetRealmsViaQuery(query));
        }

        public string region { get; set; }

        public RealmExplorer() : this("us") { }

        public RealmExplorer(string region)
        {
            this.region = region;
        }

        private string ConvertRealmListToJson(List<Realm> realmList)
        {
            return JsonConvert.SerializeObject(
                new Dictionary<string, List<Realm>> { { "realms", realmList } });
        }

        private List<Realm> GetRealmData(string url)
        {
            var jsonObject = JObject.Parse(GetJson(url));
            var realms = jsonObject["realms"];

            return JsonConvert.DeserializeObject<List<Realm>>(realms.ToString());
        }

        private string GetJson(string url)
        {
            using (var wc = new WebClient())
            {
                var jsonString = wc.DownloadString(url);
                return jsonString;
            }
        }

    }
}
