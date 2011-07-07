using System;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using WowDotNetAPI.Explorers.Models;
using System.IO;

namespace WowDotNetAPI.Explorers
{
	public class RealmExplorer : IRealmExplorer
	{
		private const string baseRealmAPIurl = "http://{0}.battle.net/api/wow/realm/status{1}";

		public string Region { get; set; }
		public JavaScriptSerializer Serializer { get; set; }
		
		public RealmExplorer() : this("us") { }

		public RealmExplorer(string region)
		{
			this.Region = region;
			this.Serializer = new JavaScriptSerializer();
		}

		public Realm GetSingleRealm(string name)
		{
			var realmList = GetMultipleRealms(name);
			return realmList == null ? null : realmList.realms.FirstOrDefault();
		}

		public RealmList GetAllRealms()
		{
			return GetRealmData(string.Format(baseRealmAPIurl, Region, string.Empty));
		}

		public RealmList GetRealmsByType(string type)
		{
			var realmList = GetRealmData(string.Format(baseRealmAPIurl, Region, string.Empty));
			realmList.FilterByType(type);
			return realmList;
		}

		public RealmList GetRealmsByPopulation(string population)
		{
			var realmList = GetRealmData(string.Format(baseRealmAPIurl, Region, string.Empty));
			realmList.FilterByPopulation(population);
			return realmList;
		}

		public RealmList GetRealmsByStatus(bool status)
		{
			var realmList = GetRealmData(string.Format(baseRealmAPIurl, Region, string.Empty));
			realmList.FilterByStatus(status);
			return realmList;
		}

		public RealmList GetRealmsByQueue(bool queue)
		{
			var realmList = GetRealmData(string.Format(baseRealmAPIurl, Region, string.Empty));
			realmList.FilterByQueue(queue);
			return realmList;
		}

		public RealmList GetMultipleRealms(params string[] names)
		{
			if (names == null 
				|| names.Length == 0
				|| names.Any(r => r == null)) return null;

			var query = "?realm=" + names[0];
			for (int i = 1; i < names.Length; i++)
			{
				query += "&realm=" + names[i];
			}

			return GetMultipleRealmsViaQuery(query);
		}

		public RealmList GetMultipleRealmsViaQuery(string query)
		{
			if (string.IsNullOrEmpty(query)) return null;

			try
			{
				return GetRealmData(string.Format(baseRealmAPIurl, Region, query));
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
			return GetJson(string.Format(baseRealmAPIurl, Region, string.Empty));
		}

		public string GetSingleRealmAsJson(string name)
		{
			return ConvertRealmListToJson(GetMultipleRealms(name));
		}

		public string GetMultipleRealmsAsJson(params string[] mames)
		{
			return ConvertRealmListToJson(GetMultipleRealms(mames));
		}
			
		public string GetRealmsViaQueryAsJson(string query)
		{
			return GetJson(string.Format(baseRealmAPIurl, Region, query));
		}

		private string ConvertRealmListToJson(RealmList realmList)
		{
			return Serializer.Serialize(new Dictionary<string, RealmList> { { "realms", realmList } });
		}

		public RealmList GetRealmData(string url)
		{
			return Serializer.Deserialize<RealmList>(GetJson(url));
		}

		private string GetJson(string url)
		{
			WebRequest request = WebRequest.Create(url);
			WebResponse res = request.GetResponse();
			StreamReader reader = new StreamReader(res.GetResponseStream());
			return reader.ReadToEnd();
		}

		//Todo: Improve URL sanitizer
		//http://stackoverflow.com/questions/25259/how-do-you-include-a-webpage-title-as-part-of-a-webpage-url/25486#25486
		private string SanitizeUrl(string url)
		{
			if (string.IsNullOrEmpty(url)) return "";

			url = Regex.Replace(url.Trim(), @"\s+", "-");
			url = Regex.Replace(url, "[#']", "");

			return url;
		}
	}
}
