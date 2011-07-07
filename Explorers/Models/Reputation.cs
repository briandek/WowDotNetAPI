using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.Models.Interfaces;

namespace WowDotNetAPI.Explorers.Models
{
	public class Reputation : IReputation
	{
		public int id { get; set; }
		public string name { get; set; }
		public int standing { get; set; }
		public int value { get; set; }
		public int max { get; set; }
	}
}
