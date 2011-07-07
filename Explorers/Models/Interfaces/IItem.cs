using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.Models.Interfaces
{
	public interface IItem
	{
		int id { get; set; }
		string name { get; set; }
		string icon { get; set; }
		int quality { get; set; }
		TooltipParameters tooltipParams { get; set; }
	}
}
