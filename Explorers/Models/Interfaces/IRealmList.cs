using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.Models.Interfaces
{
	public interface IRealmList
	{
		List<Realm> realms { get; set; }
		void FilterByQueue(bool queue);
		void FilterByStatus(bool status);
		void FilterByPopulation(string population);
		void FilterByType(string type);
	}
}
