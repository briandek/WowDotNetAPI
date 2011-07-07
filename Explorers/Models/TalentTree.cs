using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.Models.Interfaces;

namespace WowDotNetAPI.Explorers.Models
{
	public class TalentTree : ITalentTree
	{
		public string points { get; set; }
		public int total { get; set; }
	}
}
