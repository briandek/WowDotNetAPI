using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WowDotNetAPI.Explorers.Models
{
	public class Reputation
	{
		public int id { get; set; }
		public string name { get; set; }
		public int standing { get; set; }
		public int value { get; set; }
		public int max { get; set; }
	}
}
