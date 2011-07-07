using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.Models.Interfaces;

namespace WowDotNetAPI.Explorers.Models
{
	public class Item : IItem
	{
		public int id { get; set; }
		public string name { get; set; }
		public string icon { get; set; }
		public int quality { get; set; }
		public TooltipParameters tooltipParams { get; set; }
	}
}
