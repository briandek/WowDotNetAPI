using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.Models.Interfaces;

namespace WowDotNetAPI.Explorers.Models
{
	public class Profession : IProfession
	{
		public int id { get; set; }
		public string name { get; set; }
		public string icon { get; set; }
		public int rank { get; set; }
		public int max { get; set; }
		public int[] recipes { get; set; }
	}
}
