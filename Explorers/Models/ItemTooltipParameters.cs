using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WowDotNetAPI.Explorers.Models
{
	public class ItemTooltipParameters 
	{
		public int gem0 { get; set; }
		public int gem1 { get; set; }
		public int gem2 { get; set; }
		public int enchant { get; set; }
		public int reforge { get; set; }
		public int[] @set { get; set; }
		public long seed { get; set; }
		public bool extraSocket { get; set; }
		public int suffix { get; set; }
	}
}
