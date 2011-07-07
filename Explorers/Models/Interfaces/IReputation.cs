using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.Models.Interfaces
{
	public interface IReputation
	{
		int id { get; set; }
		string name { get; set; }
		int standing { get; set; }
		int value { get; set; }
		int max { get; set; }
	}
}
