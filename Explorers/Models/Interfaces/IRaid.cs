using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.Models.Interfaces
{
	public interface IRaid
	{
		string name { get; set; }
		int normal { get; set; }
		int heroic { get; set; }
		int id { get; set; }
		List<Boss> bosses { get; set; }
	}
}
