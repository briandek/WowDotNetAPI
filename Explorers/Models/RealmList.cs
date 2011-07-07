using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.Models.Interfaces;

namespace WowDotNetAPI.Explorers.Models
{
	public class RealmList : IRealmList
	{
		public List<Realm> realms { get; set; }
		
		public void FilterByQueue(bool queue)
		{
			foreach (Realm realm in realms)
			{
				if (realm.queue == queue)
					realms.Remove(realm);
			}
		}

		public void FilterByStatus(bool status)
		{
			foreach (Realm realm in realms)
			{
				if (realm.status == status)
					realms.Remove(realm);
			}
		}

		public void FilterByPopulation(string population)
		{
			foreach (Realm realm in realms)
			{
				if (realm.population.Equals(population, StringComparison.InvariantCultureIgnoreCase))
					realms.Remove(realm);
			}
		}

		public void FilterByType(string type)
		{
			foreach (Realm realm in realms)
			{
				if (realm.type.Equals(type, StringComparison.InvariantCultureIgnoreCase))
					realms.Remove(realm);
			}
		}
	}
}
