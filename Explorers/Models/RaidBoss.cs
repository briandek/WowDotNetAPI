using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WowDotNetAPI.Explorers.Models
{
	public class RaidBoss
	{
		public string name { get; set; }
		public int normalKills { get; set; }
		public int heroicKills { get; set; }
		public int id { get; set; }
	}
}
