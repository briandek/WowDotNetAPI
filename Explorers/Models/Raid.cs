using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WowDotNetAPI.Models
{
	public class Raid
	{
		public string name { get; set; }
		public int normal { get; set; }
		public int heroic { get; set; }
		public int id { get; set; }
		public IEnumerable<RaidBoss> bosses { get; set; }
	}
}
