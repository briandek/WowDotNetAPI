using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.Models.Interfaces
{
	public interface IEmblem
	{
		int icon { get; set; }
		string iconColor { get; set; }
		int border { get; set; }
		string borderColor { get; set; }
		string backgroundcolor { get; set; }
	}
}
