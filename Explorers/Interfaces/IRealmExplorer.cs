using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Net;
using WowDotNetAPI.Explorers.CharacterExplorerModels;

namespace WowDotNetAPI.Explorers.Interfaces
{
	public interface IRealmExplorer : IExplorer<Realm>
	{
		string Region { get; set; }
        IEnumerable<Realm> Realms { get; }
		
        Realm GetRealm(string name);
		IEnumerable<Realm> GetAllRealms();
		IEnumerable<Realm> GetMultipleRealms(params string[] names);
        IEnumerable<Realm> GetMultipleRealmsViaQuery(string query);
	}
}
