using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Net;
using WowDotNetAPI.Explorers.Models;

namespace WowDotNetAPI.Explorers.Interfaces
{
	public interface IRealmExplorer : IExplorer<Realm>
	{
        IEnumerable<Realm> GetRealms();
        IEnumerable<Realm> GetRealms(string region);
        IEnumerable<Realm> GetRealmsViaQuery(string region, string query);
	}
}
