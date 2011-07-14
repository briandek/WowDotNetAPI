using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WowDotNetAPI.Explorers.Models
{
	public class Profession
	{
		public int id { get; set; }
		public string name { get; set; }
		public string icon { get; set; }
		public int rank { get; set; }
		public int max { get; set; }
		public int[] recipes { get; set; }
	}
}
