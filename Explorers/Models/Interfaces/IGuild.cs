using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.Models.Interfaces
{
	public interface IGuild
	{
		string name { get; set; }
		string realm { get; set; }
		int level { get; set; }
		int members { get; set; }
		int achievementPoints { get; set; }
		Emblem emblem { get; set; }
	}
}
