using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.Models.Interfaces;

namespace WowDotNetAPI.Explorers.Models
{
	public class Guild : IGuild
	{
		public string name { get; set; }
		public string realm { get; set; }
		public int level { get; set; }
		public int members { get; set; }
		public int achievementPoints { get; set; }
		public Emblem emblem { get; set; }
	}
}
