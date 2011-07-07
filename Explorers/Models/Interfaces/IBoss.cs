using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.Models.Interfaces
{
	public interface IBoss
	{
		string name { get; set; }
		int normalKills { get; set; }
		int heroicKills { get; set; }
		int id { get; set; }
	}
}
