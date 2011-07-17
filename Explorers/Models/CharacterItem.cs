using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WowDotNetAPI.Explorers.Models
{
	public class CharacterItem
	{
		public int id { get; set; }
		public string name { get; set; }
		public string icon { get; set; }
		public int quality { get; set; }
		public ItemTooltipParameters tooltipParams { get; set; }
	}
}
