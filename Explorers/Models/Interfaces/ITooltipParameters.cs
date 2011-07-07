using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.Models.Interfaces
{
	public interface ITooltipParameters
	{
		int gem0 { get; set; }
		int gem1 { get; set; }
		int gem2 { get; set; }
		int enchant { get; set; }
		int reforge { get; set; }
		int[] @set { get; set; }
		long seed { get; set; }
		bool extraSocket { get; set; }
		int suffix { get; set; }
	}
}
