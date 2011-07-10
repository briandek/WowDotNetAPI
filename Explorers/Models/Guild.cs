using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WowDotNetAPI.Explorers.Models
{
	public class Guild
	{
		public string name { get; set; }
		public string realm { get; set; }
		public int level { get; set; }
		public int members { get; set; }
		public int achievementPoints { get; set; }
		public Emblem emblem { get; set; }
	}
}
