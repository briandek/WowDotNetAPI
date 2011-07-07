using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.Models.Interfaces
{
	public interface IGlyph
	{
		int glyph { get; set; }
		int item { get; set; }
		string name { get; set; }
		string icon { get; set; }
	}
}
