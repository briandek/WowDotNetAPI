using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.Models.Interfaces;

namespace WowDotNetAPI.Explorers.Models
{
	public class Raid : IRaid
	{
		public string name { get; set; }
		public int normal { get; set; }
		public int heroic { get; set; }
		public int id { get; set; }
		public List<Boss> bosses { get; set; }
	}
}
