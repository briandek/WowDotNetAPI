using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.Models.Interfaces;

namespace WowDotNetAPI.Explorers.Models
{
	public class Boss : IBoss
	{
		public string name { get; set; }
		public int normalKills { get; set; }
		public int heroicKills { get; set; }
		public int id { get; set; }
	}
}
