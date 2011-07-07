using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Net;
using WowDotNetAPI.Explorers.Models;

namespace WowDotNetAPI.Explorers
{
	public interface IRealmExplorer : IExplorer
	{
		string Region { get; set; }

		Realm GetSingleRealm(string name);
		string GetSingleRealmAsJson(string name);

		RealmList GetAllRealms();
		string GetAllRealmsAsJson();

		RealmList GetRealmsByType(string type);
		string GetRealmsByTypeAsJson(string type);

		RealmList GetRealmsByPopulation(string population);
		string GetRealmsByPopulationAsJson(string population);

		RealmList GetRealmsByStatus(bool status);
		string GetRealmsByStatusAsJson(bool status);

		RealmList GetRealmsByQueue(bool queue);
		string GetRealmsByQueueAsJson(bool queue);

		RealmList GetMultipleRealms(params string[] names);
		string GetMultipleRealmsAsJson(params string[] names);

		RealmList GetMultipleRealmsViaQuery(string query);
		string GetRealmsViaQueryAsJson(string query);
	}
}
